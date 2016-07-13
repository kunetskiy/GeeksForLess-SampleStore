using GeeksForLess_SampleStore.Logic.Common;
using GeeksForLess_SampleStore.Logic.ValuedObjects;

namespace GeeksForLess_SampleStore.Logic.Entities
{
    public class Customer : AggregateRoot
    {
        public virtual VisitingCard VisitingCard { get; }

        public virtual ShoppingCart Cart { get; }

        protected Customer() { }

        public Customer(VisitingCard card) : this()
        {
            Cart = ShoppingCart.Empty;
        }
    }
}
