using GeeksForLess_SampleStore.Logic.Common;

namespace GeeksForLess_SampleStore.Logic.Entities
{
    public class Product : Entity
    {
        protected Product() { }

        private Product(int id, string title, decimal price, int categoryId)
        {
            Id = id;
            Title = title;
            Price = price;
            CategoryId = categoryId;
        }

        public string Title { get; }
        public decimal Price { get; }
        public int CategoryId { get; }
        public static Product TempProduct1 => new Product(1, "TempProd1", 50.5m, 1);
        public static Product TempProduct2 => new Product(2, "TempProd2", 150.9m, 2);
    }
}
