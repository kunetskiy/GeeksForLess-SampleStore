using GeeksForLess_SampleStore.Core;
using GeeksForLess_SampleStore.Core.ValuedObjects;
using GeeksForLess_SampleStore.ShoppingCart.ValuedObjects;

namespace GeeksForLess_SampleStore.ShoppingCart.Entities
{
    public class ShoppingCartItem : Entity
    {
        private int _cartId;
        public ProductBox Box { get; set; }
        public Address Address { get; set; }

        protected ShoppingCartItem() { }
        internal ShoppingCartItem(int cartId, Product product, int quantity)
        {
            _cartId = cartId;
            Box = new ProductBox(product, quantity);
            Address = Address.Empty;
        }

        internal ShoppingCartItem(int cartId, Product product, int quantity, Address address) : this(cartId, product, quantity)
        {
            Address = address;
        }
    }
}
