using GeeksForLess_SampleStore.Logic.Common;
using GeeksForLess_SampleStore.Logic.ValuedObjects;

namespace GeeksForLess_SampleStore.Logic.Entities
{
    public class ShoppingCartItem : Entity
    {
        public ShoppingCart Cart { get; set; }
        public ProductBox Box { get; }
        public Address Address { get; }

        protected ShoppingCartItem() { }
        internal ShoppingCartItem(ShoppingCart cart, Product product, int quantity)
        {
            this.Cart = cart;
            this.Box = new ProductBox(product, quantity);
            this.Address = Address.Empty;
        }

        internal ShoppingCartItem(ShoppingCart cart, Product product, int quantity, Address address) : this(cart, product, quantity)
        {
            this.Address = address;
        }
    }
}
