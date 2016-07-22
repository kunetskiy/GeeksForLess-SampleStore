using GeeksForLess_SampleStore.Logic.Common;
using GeeksForLess_SampleStore.Logic.ValuedObjects;

namespace GeeksForLess_SampleStore.Logic.Entities
{
    public class Customer : AggregateRoot
    {
        public VisitingCard VisitingCard { get; }

        private ShoppingCart _cart;

        public ShoppingCart Cart
        {
            get
            {
                if (_cart == null)
                {
                    _cart = new ShoppingCart(this.Id);
                }
                return _cart;
            }
        }

        protected Customer() { }

        public Customer(VisitingCard card) : this()
        {
            VisitingCard = card;
        }
    }
}
