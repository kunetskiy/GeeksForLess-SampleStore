CREATE TABLE [dbo].[Ids] (
    [EntityName] NVARCHAR (100) NOT NULL,
    [NextHigh]   INT            NOT NULL,
    CONSTRAINT [PK_Ids] PRIMARY KEY CLUSTERED ([EntityName] ASC)
);

