CREATE TABLE [dbo].[Product] (
	[ProductId]                INT NOT NULL,
	[CategoryId]        INT            NOT NULL,
	[Title] nvarchar(200) not null,
	[Price]             DECIMAL (8, 2) NOT NULL,
	[AvailableQuantity] int not null default(0)
	PRIMARY KEY CLUSTERED ([ProductId] ASC),
	CONSTRAINT FK_Product_Category FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category]([CategoryId])
);

