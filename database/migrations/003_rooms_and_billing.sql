/* =====================================================================
   Migration 003 - Room status constraints + customer billing fields
   ---------------------------------------------------------------------
   Target   : SQL Server 2012 or later
   Database : HotelDB
   Purpose  : Prepare the database for check-out and billing.

   The script is idempotent and safe to run more than once.
   ===================================================================== */

USE HotelDB;
GO

/* ---------------------------------------------------------------------
   1) Normalize legacy room types and statuses.
   --------------------------------------------------------------------- */
UPDATE dbo.Rooms
SET Room_Type = 'Suite'
WHERE Room_Type = 'Suit';
GO

UPDATE dbo.Rooms
SET Status = 'Free'
WHERE Status IS NULL OR Status NOT IN ('Free', 'Busy');
GO

/* ---------------------------------------------------------------------
   2) Replace the legacy default ('No') with 'Free'.
   --------------------------------------------------------------------- */
DECLARE @defaultName sysname;
DECLARE @dropSql nvarchar(4000);

SELECT @defaultName = dc.name
FROM sys.default_constraints dc
INNER JOIN sys.columns c
    ON c.object_id = dc.parent_object_id
   AND c.column_id = dc.parent_column_id
WHERE dc.parent_object_id = OBJECT_ID(N'dbo.Rooms')
  AND c.name = N'Status';

IF @defaultName IS NOT NULL
BEGIN
    SET @dropSql = N'ALTER TABLE dbo.Rooms DROP CONSTRAINT ' + QUOTENAME(@defaultName);
    EXEC sp_executesql @dropSql;
END
GO

ALTER TABLE dbo.Rooms
    ADD CONSTRAINT DF_Rooms_Status DEFAULT ('Free') FOR Status;
GO

/* The application always treats Status as required. */
ALTER TABLE dbo.Rooms
    ALTER COLUMN Status VARCHAR(5) NOT NULL;
GO

/* ---------------------------------------------------------------------
   3) Restrict room status to the values the application understands.
   --------------------------------------------------------------------- */
IF NOT EXISTS (
    SELECT 1
    FROM sys.check_constraints
    WHERE name = N'CK_Rooms_Status'
      AND parent_object_id = OBJECT_ID(N'dbo.Rooms'))
BEGIN
    ALTER TABLE dbo.Rooms WITH CHECK
        ADD CONSTRAINT CK_Rooms_Status CHECK (Status IN ('Free', 'Busy'));
END
GO

/* ---------------------------------------------------------------------
   4) Billing columns on Customers.
      Customer_Rate  : the nightly rate captured at check-in.
      Customer_Total : the final bill, written when the guest checks out.
   --------------------------------------------------------------------- */
IF COL_LENGTH(N'dbo.Customers', N'Customer_Rate') IS NULL
BEGIN
    ALTER TABLE dbo.Customers
        ADD Customer_Rate DECIMAL(10, 2) NULL;
END
GO

IF COL_LENGTH(N'dbo.Customers', N'Customer_Total') IS NULL
BEGIN
    ALTER TABLE dbo.Customers
        ADD Customer_Total DECIMAL(12, 2) NULL;
END
GO

/* ---------------------------------------------------------------------
   5) Backfill the new columns for existing rows.
   --------------------------------------------------------------------- */
UPDATE c
SET c.Customer_Rate = r.Price
FROM dbo.Customers c
INNER JOIN dbo.Rooms r ON r.Room_ID = c.Customer_Room_ID
WHERE c.Customer_Rate IS NULL;
GO

UPDATE c
SET c.Customer_Total =
    (CASE
        WHEN DATEDIFF(DAY, c.Customer_CheckIn, c.Customer_CheckOut) < 1
            THEN 1
        ELSE DATEDIFF(DAY, c.Customer_CheckIn, c.Customer_CheckOut)
     END) * c.Customer_Rate
FROM dbo.Customers c
WHERE c.Customer_IsCheckOut = 'Yes'
  AND c.Customer_CheckOut IS NOT NULL
  AND c.Customer_Rate IS NOT NULL
  AND c.Customer_Total IS NULL;
GO

/* ---------------------------------------------------------------------
   6) Restrict the check-out flag to Yes / No.
   --------------------------------------------------------------------- */
UPDATE dbo.Customers
SET Customer_IsCheckOut = 'No'
WHERE Customer_IsCheckOut IS NULL
   OR Customer_IsCheckOut NOT IN ('Yes', 'No');
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.check_constraints
    WHERE name = N'CK_Customers_IsCheckOut'
      AND parent_object_id = OBJECT_ID(N'dbo.Customers'))
BEGIN
    ALTER TABLE dbo.Customers WITH CHECK
        ADD CONSTRAINT CK_Customers_IsCheckOut
        CHECK (Customer_IsCheckOut IN ('Yes', 'No'));
END
GO

/* ---------------------------------------------------------------------
   7) Speed up the "is this room occupied?" checks.
   --------------------------------------------------------------------- */
IF NOT EXISTS (
    SELECT 1
    FROM sys.indexes
    WHERE name = N'IX_Customers_Room_Active'
      AND object_id = OBJECT_ID(N'dbo.Customers'))
BEGIN
    CREATE INDEX IX_Customers_Room_Active
        ON dbo.Customers (Customer_Room_ID, Customer_IsCheckOut)
        INCLUDE (Customer_CheckIn);
END
GO

PRINT 'Migration 003 completed.';
GO
