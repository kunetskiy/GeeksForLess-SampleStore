using GeeksForLess_SampleStore.Logic.Common;
using GeeksForLess_SampleStore.Logic.ValuedObjects;

namespace GeeksForLess_SampleStore.Logic.Entities
{
    public class ShoppingCartItem : Entity
    {
        protected virtual int ShoppingCartId { get; }
        public virtual ProductBox Box { get; }
        public virtual Address Address { get; }

        protected ShoppingCartItem() { }
        internal ShoppingCartItem(Product product, int quantity)
        {
            this.Box = new ProductBox(product, quantity);
            this.Address = Address.Empty;
        }

        internal ShoppingCartItem(Product product, int quantity, Address address) : this(product, quantity)
        {
            this.Address = address;
        }
    }
}
