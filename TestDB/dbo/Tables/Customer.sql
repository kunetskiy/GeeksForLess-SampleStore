CREATE TABLE [dbo].[Customer] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (200) NULL,
    [LastName]  NVARCHAR (200) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

