using System.Collections.Generic;
using System.Linq;
using GeeksForLess_SampleStore.Logic.Common;
using GeeksForLess_SampleStore.Logic.SharedKernel;

namespace GeeksForLess_SampleStore.Logic.Entities
{
    public class ShoppingCart : Entity
    {
        public static ShoppingCart Empty
        {
            get
            {
                return new ShoppingCart();
            }
        }

        public void AddToCart(int productId, int quantity)
        {
            this._items.Add(new ShoppingCartItem(productId, quantity));
        }

        public int ItemsCount
        {
            get
            {
                return Items.Sum(item => item.Box.Quantity);
            }
        }

        public void AddToCart(int productId, int quantity, Address address)
        {
            this._items.Add(new ShoppingCartItem(productId, quantity, address));
        }

        private List<ShoppingCartItem> _items = new List<ShoppingCartItem>();
        public IEnumerable<ShoppingCartItem> Items => _items;

        private ShoppingCart() { }
    }
}
