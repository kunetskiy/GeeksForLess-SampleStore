using GeeksForLess_SampleStore.Core;
using GeeksForLess_SampleStore.ShoppingCart.ValuedObjects;

namespace GeeksForLess_SampleStore.ShoppingCart.Entities
{
    public class Customer : AggregateRoot
    {
        public VisitingCard VisitingCard { get; private set; }

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
