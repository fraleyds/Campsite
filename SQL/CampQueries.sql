﻿--CREATE DATABASE CampsiteDB
--GO;

CREATE TABLE dbo.Owners
(OwnerID INT IDENTITY(1,1) PRIMARY KEY CLUSTERED NOT NULL,
LastName NVARCHAR(75) NOT NULL,
FirstName NVARCHAR(75) NOT NULL,
Email NVARCHAR(75) NOT NULL,
JoinDate DATE NOT NULL);

CREATE TABLE dbo.Renters
(RenterID INT IDENTITY(1,1) PRIMARY KEY CLUSTERED NOT NULL,
LastName NVARCHAR(75) NOT NULL,
FirstName NVARCHAR(75) NOT NULL,
Email NVARCHAR(75) NOT NULL,
JoinDate DATE NOT NULL,
Renting BIT NOT NULL);

CREATE TABLE dbo.Items
(ItemID INT IDENTITY(1,1) PRIMARY KEY CLUSTERED NOT NULL,
OwnerID INT NOT NULL,
LastName NVARCHAR(75) NOT NULL,
FirstName NVARCHAR(75) NOT NULL,
Email NVARCHAR(75) NOT NULL,
JoinDate DATE NOT NULL,
CONSTRAINT [FK_dbo.Items_dbo.Owners_OwnerID] FOREIGN KEY ([OwnerID]) REFERENCES [dbo].[Owners] ([OwnerID]) ON DELETE CASCADE);
GO

CREATE NONCLUSTERED INDEX [IX_OwnerID]
    ON [dbo].[Items]([OwnerID] ASC);
