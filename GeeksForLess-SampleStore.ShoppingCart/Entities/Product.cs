using GeeksForLess_SampleStore.Core;

namespace GeeksForLess_SampleStore.ShoppingCart.Entities
{
    public class Product : AggregateRoot
    {
        protected Product() { }

        public string Title { get; private set; }
        public decimal Price { get; private set; }
        public int CategoryId { get; private set; }
    }
}
