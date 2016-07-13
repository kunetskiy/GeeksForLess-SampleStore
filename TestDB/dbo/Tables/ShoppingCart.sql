CREATE TABLE [dbo].[ShoppingCart] (
	[Id]         INT IDENTITY (1, 1) NOT NULL,
	[CustomerId] INT NOT NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT FK_ShoppingCart_Customer FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer]([Id])
);

