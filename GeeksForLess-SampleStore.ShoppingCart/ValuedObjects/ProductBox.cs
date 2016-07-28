using GeeksForLess_SampleStore.Core;
using GeeksForLess_SampleStore.ShoppingCart.Entities;

namespace GeeksForLess_SampleStore.ShoppingCart.ValuedObjects
{
    public sealed class ProductBox : ValueObject<ProductBox>
    {
        public Product Product { get; }
        public int Quantity { get; }

        private ProductBox() { }
        public ProductBox(Product product, int quantity) : this()
        {
            Product = product;
            Quantity = quantity;
        }

        protected override bool EqualsCore(ProductBox other)
        {
            return this.Product.Equals(other.Product)
                && this.Quantity.Equals(other.Quantity);
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = this.Product.GetHashCode();
                hashCode = (hashCode * this.Quantity) ^ 255;

                return hashCode;
            }
        }

        public ProductBox ChangeQuantity(int quantity)
        {
            return new ProductBox(this.Product, quantity);
        }
    }
}