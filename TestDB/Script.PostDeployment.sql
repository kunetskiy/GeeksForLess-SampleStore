-- Reference Data for Category
Merge into Category as target
using (values
	(1, 'Food'),
	(2, 'Clothes')
)
as source (CategoryId, Title)
on target.CategoryId = source.CategoryId
when matched then
update set Title = source.Title
when not matched by target then
insert (CategoryId, Title) values (CategoryId, Title)
when not matched by source then
delete;

-- Reference Data for Product
Merge into Product as target
using (values
	(1, 1, 'Bread', 50, 10),
	(2, 1, 'Pizza', 150, 5),
	(3, 2, 'T-shirt', 850, 3),
	(4, 2, 'Jacket', 1500, 1)
)
as source (ProductId, CategoryId, Title, Price, QuantityInStock)
on target.ProductId = source.ProductId
when matched then
update set CategoryId = source.CategoryId, Title = source.Title, Price = source.Price, QuantityInStock = source.QuantityInStock
when not matched by target then
insert (ProductId, CategoryId, Title, Price, QuantityInStock) values (ProductId, CategoryId, Title, Price, QuantityInStock)
when not matched by source then
delete;


-- Reference Data for Customer
Merge into Customer as target
using (values
	(1, 'Santa', 'Claus'),
	(2, 'Jack', 'Skellington')
)
as source (CustomerId, FirstName, LastName)
on target.CustomerId = source.CustomerId
when matched then
update set FirstName = source.FirstName, LastName = source.LastName
when not matched by target then
insert (CustomerId, FirstName, LastName) values (CustomerId, FirstName, LastName)
when not matched by source then
delete;