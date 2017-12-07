CREATE TABLE [dbo].[Items] (
    [ItemID]    INT           IDENTITY (1, 1) NOT NULL,
    [OwnerID]   INT           NOT NULL,
    [Type]  NVARCHAR (75) NOT NULL,
    [Model] NVARCHAR (75) NOT NULL,
    [Price]     DECIMAL(18, 2) NOT NULL,
    [Condition]  NVARCHAR(75)          NOT NULL,
    [Available] BIT NOT NULL, 
    PRIMARY KEY CLUSTERED ([ItemID] ASC),
    CONSTRAINT [FK_dbo.Items_dbo.Owners_OwnerID] FOREIGN KEY ([OwnerID]) REFERENCES [dbo].[Owners] ([OwnerID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_OwnerID]
    ON [dbo].[Items]([OwnerID] ASC);

