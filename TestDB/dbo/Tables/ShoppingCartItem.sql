CREATE TABLE [dbo].[ShoppingCartItem] (
	[ShoppingCartItemId]             INT NOT NULL,
	[ShoppingCartId] INT            NOT NULL,
	[ProductId]      INT            NOT NULL,
	[Quantity]       INT            NOT NULL,
	[Country]        NVARCHAR (200) NULL,
	[State]          NVARCHAR (200) NULL,
	[ZipCode]        NVARCHAR (200) NULL,
	[City]           NVARCHAR (200) NULL,
	[AddressLine]    NVARCHAR (200) NULL,
	PRIMARY KEY CLUSTERED ([ShoppingCartItemId] ASC),
	CONSTRAINT FK_ShoppingCartItem_ShoppingCart FOREIGN KEY ([ShoppingCartId]) REFERENCES [dbo].[ShoppingCart]([ShoppingCartId]),
	CONSTRAINT FK_ShoppingCartItem_Product FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product]([ProductId])
);

