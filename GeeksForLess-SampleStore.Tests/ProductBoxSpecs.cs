using FluentAssertions;
using GeeksForLess_SampleStore.Logic.ValuedObjects;
using Xunit;
using static GeeksForLess_SampleStore.Logic.Entities.Product;

namespace GeeksForLess_SampleStore.Tests
{
    public class ProductBoxSpecs
    {
        [Fact]
        public void Two_boxes_are_equal_when_contain_same_quantity_of_same_product()
        {
            ProductBox pb1 = new ProductBox(Bread, 5);
            ProductBox pb2 = new ProductBox(Bread, 5);

            pb1.Should().Be(pb2);
        }

        [Fact]
        public void Two_boxes_are_not_equal_when_contain_different_quantity_of_same_product()
        {
            ProductBox pb1 = new ProductBox(Bread, 6);
            ProductBox pb2 = new ProductBox(Bread, 5);

            pb1.Should().NotBe(pb2);
        }

        [Fact]
        public void Two_boxes_are_not_equal_when_contain_same_quantity_of_different_product()
        {
            ProductBox pb1 = new ProductBox(Bread, 5);
            ProductBox pb2 = new ProductBox(TShirt, 5);

            pb1.Should().NotBe(pb2);
        }

        public void Correct_quantity_after_changing()
        {
            ProductBox pb1 = new ProductBox(Bread, 1);
            pb1 = pb1.ChangeQuantity(5);

            pb1.Quantity.Should().Be(5);
        }
    }
}
