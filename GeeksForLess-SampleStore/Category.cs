using System.Collections.Generic;

namespace GeeksForLess_SampleStore.Logic
{
    public class Category
    {
        public int Id { get; }
        public string Title { get; }
        public IList<Product> Products { get; }
    }
}