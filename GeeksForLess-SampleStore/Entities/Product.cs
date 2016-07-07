using GeeksForLess_SampleStore.Logic.Common;

namespace GeeksForLess_SampleStore.Logic.Entities
{
    public class Product : AggregateRoot
    {
        public string Title { get; }
        public decimal Price { get; }
        public int CategoryId { get; }
    }
}
