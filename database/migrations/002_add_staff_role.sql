/* =====================================================================
   Migration 002 - Staff roles + unique user names
   ---------------------------------------------------------------------
   Target : existing HotelDB databases created before Phase 3.
   Safe   : idempotent, can be run more than once.

   What it does:
     1. Adds Staff_Role ('Admin' / 'Staff', default 'Staff').
     2. Rejects duplicate Staff_UserName values, then adds a UNIQUE constraint.
     3. Promotes the first staff member to Admin if no Admin exists yet.

   After running this script, sign in with the promoted account and use
   the Staff screen to create a proper administrator account.
   ===================================================================== */

USE HotelDB;
GO

/* 1) Role column ------------------------------------------------------ */
IF COL_LENGTH('dbo.Staff', 'Staff_Role') IS NULL
BEGIN
    ALTER TABLE dbo.Staff
        ADD Staff_Role VARCHAR(20) NOT NULL
            CONSTRAINT DF_Staff_Role DEFAULT ('Staff');
END
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.check_constraints
    WHERE name = 'CK_Staff_Role'
      AND parent_object_id = OBJECT_ID('dbo.Staff'))
BEGIN
    ALTER TABLE dbo.Staff
        ADD CONSTRAINT CK_Staff_Role
            CHECK (Staff_Role IN ('Admin', 'Staff'));
END
GO

/* 2) Unique user names ------------------------------------------------ */
IF EXISTS (
    SELECT Staff_UserName
    FROM dbo.Staff
    GROUP BY Staff_UserName
    HAVING COUNT(*) > 1)
BEGIN
    THROW 50001, 'Cannot add UQ_Staff_UserName: duplicate user names exist. Fix them first.', 1;
END
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.key_constraints
    WHERE name = 'UQ_Staff_UserName'
      AND parent_object_id = OBJECT_ID('dbo.Staff'))
BEGIN
    ALTER TABLE dbo.Staff
        ADD CONSTRAINT UQ_Staff_UserName UNIQUE (Staff_UserName);
END
GO

/* 3) Bootstrap an administrator --------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM dbo.Staff WHERE Staff_Role = 'Admin')
BEGIN
    UPDATE dbo.Staff
    SET Staff_Role = 'Admin'
    WHERE Staff_ID = (SELECT MIN(Staff_ID) FROM dbo.Staff);
END
GO
