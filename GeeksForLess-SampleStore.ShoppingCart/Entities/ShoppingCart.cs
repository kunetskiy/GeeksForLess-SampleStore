using System.Collections.Generic;
using System.Linq;
using GeeksForLess_SampleStore.Core;

namespace GeeksForLess_SampleStore.ShoppingCart.Entities
{
    public class ShoppingCart : Entity
    {
        protected ShoppingCart()
        {
            Items = new List<ShoppingCartItem>();
        }

        internal ShoppingCart(int customerId) : this()
        {
            Id = customerId;
        }

        private IList<ShoppingCartItem> Items { get; set; }

        public IReadOnlyList<ShoppingCartItem> GetAllItems()
        {
            return Items
                    .Select(item => item)
                    .ToList();
        }

        public void RemoveFromCart(int productId)
        {
            var itemToRemove = Items.FirstOrDefault(item => item.Box.Product.Id == productId);
            if (itemToRemove != null)
            {
                Items.Remove(itemToRemove);
            }
        }

        public void ClearCart()
        {
            Items.Clear();
        }

        public decimal Total => Items.Sum(item => item.Box.Product.Price * item.Box.Quantity);

        public int TotalCount => Items.Sum(item => item.Box.Quantity);

        public void AddToCart(Product product, int quantity)
        {
            //try to find same product in cart
            var item = Items.SingleOrDefault(sci => sci.Box.Product == product);
            if (item != null)
            {
                //in case when item found we change the quantity
                item.Box = item.Box.ChangeQuantity(quantity);
            }
            else
            {
                Items.Add(new ShoppingCartItem(Id, product, quantity));
            }
        }
    }
}
