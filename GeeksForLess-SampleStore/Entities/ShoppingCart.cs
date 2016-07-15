using System.Collections.Generic;
using System.Linq;
using GeeksForLess_SampleStore.Logic.Common;
using GeeksForLess_SampleStore.Logic.ValuedObjects;

namespace GeeksForLess_SampleStore.Logic.Entities
{
    public class ShoppingCart : Entity
    {
        public static ShoppingCart Empty => new ShoppingCart();

        protected ShoppingCart() { }

        private List<ShoppingCartItem> _items = new List<ShoppingCartItem>();
        public virtual IEnumerable<ShoppingCartItem> Items => _items;

        public void AddToCart(Product product, int quantity)
        {
            this._items.Add(new ShoppingCartItem(product, quantity));
        }

        public void RemoveFromCart(int itemId)
        {
            var itemToRemove = this._items.FirstOrDefault(item => item.Id == itemId);
            if (itemToRemove != null)
            {
                this._items.Remove(itemToRemove);
            }
        }

        public void ClearCart()
        {
            this._items.Clear();
        }

        public decimal Total => Items.Sum(item => item.Box.Product.Price * item.Box.Quantity);

        public int ItemsCount => Items.Sum(item => item.Box.Quantity);

        public void AddToCart(Product product, int quantity, Address address)
        {
            this._items.Add(new ShoppingCartItem(product, quantity, address));
        }
    }
}
