/* =====================================================================
   Hotel Management System - Database Schema
   ---------------------------------------------------------------------
   Target   : SQL Server 2012 or later
   Database : HotelDB
   Purpose  : Reproducible schema for a fresh installation.

   The script is idempotent: it only creates objects that do not exist.
   It never drops or modifies existing tables/data.
   ===================================================================== */

IF DB_ID(N'HotelDB') IS NULL
BEGIN
    CREATE DATABASE HotelDB;
END
GO

USE HotelDB;
GO

/* ---------------------------------------------------------------------
   1) Rooms
   --------------------------------------------------------------------- */
IF OBJECT_ID(N'dbo.Rooms', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Rooms
    (
        Room_ID   INT           IDENTITY(1,1) NOT NULL,
        Room_NO   VARCHAR(10)   NOT NULL,
        Room_Type VARCHAR(10)   NOT NULL,
        Bed       VARCHAR(10)   NOT NULL,
        Price     DECIMAL(10,2) NOT NULL,
        Status    VARCHAR(5)    NULL
                  CONSTRAINT DF_Rooms_Status DEFAULT ('No'),

        CONSTRAINT PK_Rooms PRIMARY KEY CLUSTERED (Room_ID),
        CONSTRAINT UQ_Rooms_Room_NO UNIQUE (Room_NO)
    );
END
GO

/* ---------------------------------------------------------------------
   2) Customers
   --------------------------------------------------------------------- */
IF OBJECT_ID(N'dbo.Customers', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Customers
    (
        Customer_ID         INT           IDENTITY(1,1) NOT NULL,
        Customer_Name       VARCHAR(75)   NOT NULL,
        Customer_Mobile     VARCHAR(25)   NOT NULL,
        Customer_Nationality VARCHAR(25)  NOT NULL,
        Customer_Gender     VARCHAR(50)   NOT NULL,
        Customer_DateOfBirth DATE         NOT NULL,
        Customer_ID_Proof   VARCHAR(30)   NOT NULL,
        Customer_Address    VARCHAR(350)  NOT NULL,
        Customer_CheckIn    DATE          NOT NULL,
        Customer_CheckOut   DATE          NULL,
        Customer_IsCheckOut VARCHAR(5)    NOT NULL
                            CONSTRAINT DF_Customers_IsCheckOut DEFAULT ('No'),
        Customer_Room_ID    INT           NOT NULL,

        CONSTRAINT PK_Customers PRIMARY KEY CLUSTERED (Customer_ID),
        CONSTRAINT FK_Customers_Rooms
            FOREIGN KEY (Customer_Room_ID) REFERENCES dbo.Rooms (Room_ID)
    );
END
GO

/* ---------------------------------------------------------------------
   3) Staff
   --------------------------------------------------------------------- */
IF OBJECT_ID(N'dbo.Staff', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Staff
    (
        Staff_ID       INT          IDENTITY(1,1) NOT NULL,
        Staff_Name     VARCHAR(75)  NOT NULL,
        Staff_Mobile   VARCHAR(25)  NOT NULL,
        Staff_Gender   VARCHAR(50)  NOT NULL,
        Staff_Email    VARCHAR(120) NOT NULL,
        Staff_UserName VARCHAR(150) NOT NULL,
        Staff_Password VARCHAR(150) NOT NULL,

        CONSTRAINT PK_Staff PRIMARY KEY CLUSTERED (Staff_ID)
    );
END
GO

/* =====================================================================
   OPTIONAL: sample rooms for a quick demo.
   Uncomment and run only on an empty database.
   ===================================================================== */
-- INSERT INTO dbo.Rooms (Room_NO, Room_Type, Bed, Price, Status) VALUES
--     ('101', 'Single', 'Single', 250.00, 'Free'),
--     ('102', 'Single', 'Single', 250.00, 'Free'),
--     ('201', 'Double', 'Double', 400.00, 'Free'),
--     ('202', 'Double', 'Queen',  450.00, 'Free'),
--     ('301', 'Twin',   'Double', 500.00, 'Free'),
--     ('302', 'Triple', 'King',   650.00, 'Free');
-- GO

/* =====================================================================
   NOTE (intentional): this schema matches the legacy application
   exactly, including known limitations that will be addressed later:
     - text columns use VARCHAR (no Unicode / Arabic support)
     - no CHECK constraints on Status / Gender
     - Rooms.Status default is 'No' instead of 'Free'
     - Staff_Password stores plain text (to be replaced by a hash)
   ===================================================================== */
