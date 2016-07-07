using GeeksForLess_SampleStore.Logic.Common;
using GeeksForLess_SampleStore.Logic.SharedKernel;
using GeeksForLess_SampleStore.Logic.ValuedObjects;

namespace GeeksForLess_SampleStore.Logic.Entities
{
    public class ShoppingCartItem : Entity
    {
        public ProductBox Box { get; }
        public Address Address { get; }

        private ShoppingCartItem() { }
        public ShoppingCartItem(int productId, int quantity)
        {
            this.Box = new ProductBox(productId, quantity);
            this.Address = Address.Empty;
        }

        public ShoppingCartItem(int productId, int quantity, Address address) : this(productId, quantity)
        {
            this.Address = address;
        }
    }
}
