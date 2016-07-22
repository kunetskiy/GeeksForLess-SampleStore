using System.Collections.Generic;
using System.Linq;
using GeeksForLess_SampleStore.Logic.Common;
using GeeksForLess_SampleStore.Logic.ValuedObjects;

namespace GeeksForLess_SampleStore.Logic.Entities
{
    public class ShoppingCart : Entity
    {
        public static ShoppingCart Empty => new ShoppingCart();

        protected ShoppingCart()
        {
            this.Items = new List<ShoppingCartItem>();
        }

        internal ShoppingCart(int customerId) : this()
        {
            this.Id = customerId;
        }

        //public virtual Customer Customer { get; set; }

        public IList<ShoppingCartItem> Items { get; set; }

        public void RemoveFromCart(int itemId)
        {
            var itemToRemove = this.Items.FirstOrDefault(item => item.Id == itemId);
            if (itemToRemove != null)
            {
                this.Items.Remove(itemToRemove);
            }
        }

        public void ClearCart()
        {
            this.Items.Clear();
        }

        public decimal Total => Items.Sum(item => item.Box.Product.Price * item.Box.Quantity);

        public int ItemsCount => Items.Sum(item => item.Box.Quantity);

        public void AddToCart(Product product, int quantity)
        {
            this.Items.Add(new ShoppingCartItem(this, product, quantity));
        }

        public void AddToCart(Product product, int quantity, Address address)
        {
            this.Items.Add(new ShoppingCartItem(this, product, quantity, address));
        }
    }
}
