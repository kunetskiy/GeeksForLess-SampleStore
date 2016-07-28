using GeeksForLess_SampleStore.Core;

namespace GeeksForLess_SampleStore.ShoppingCart.Entities
{
    public class Category : Entity
    {
        protected Category()
        { }

        public virtual string Title { get; private set; }
    }
}
