CREATE TABLE [dbo].[ShoppingCart] (
	[ShoppingCartId]         INT NOT NULL,
    PRIMARY KEY CLUSTERED ([ShoppingCartId] ASC),
	CONSTRAINT FK_ShoppingCart_Customer FOREIGN KEY ([ShoppingCartId]) REFERENCES [dbo].[Customer]([CustomerId])
);

