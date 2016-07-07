using GeeksForLess_SampleStore.Logic.Common;

namespace GeeksForLess_SampleStore.Logic.ValuedObjects
{
    public class ProductBox : ValueObject<ProductBox>
    {
        public int ProductId { get; }
        public int Quantity { get; }

        private ProductBox() { }
        public ProductBox(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        internal override bool EqualsCore(ProductBox other)
        {
            return this.ProductId.Equals(other.ProductId)
                && this.Quantity.Equals(other.Quantity);
        }

        internal override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = this.ProductId;
                hashCode = (hashCode * this.Quantity) ^ 255;

                return hashCode;
            }
        }

        public ProductBox ChangeQuantity(int quantity)
        {
            return new ProductBox(this.ProductId, quantity);
        }
    }
}