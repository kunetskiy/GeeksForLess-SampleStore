using GeeksForLess_SampleStore.Logic.Common;

namespace GeeksForLess_SampleStore.Logic.Entities
{
    public class Product : AggregateRoot
    {
        protected Product() { }

        private Product(int id, int categoryId, string title, decimal price)
        {
            Id = id;
            Title = title;
            Price = price;
            CategoryId = categoryId;
        }

        public virtual string Title { get; }
        public virtual decimal Price { get; }
        public virtual int CategoryId { get; }
        public static Product Bread => new Product(1, 1, "Bread", 50m);
        public static Product TShirt => new Product(2, 2, "T-shirt", 850m);
    }
}
