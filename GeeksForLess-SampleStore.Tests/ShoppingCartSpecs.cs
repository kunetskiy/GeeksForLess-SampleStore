using System.Linq;
using FluentAssertions;
using GeeksForLess_SampleStore.Logic.Entities;
using GeeksForLess_SampleStore.Logic.SharedKernel;
using Xunit;

namespace GeeksForLess_SampleStore.Tests
{
    public class ShoppingCartSpecs
    {
        [Fact]
        public void Items_count_inside_correct_after_adding_new_one()
        {
            ShoppingCart cart = ShoppingCart.Empty;
            cart.AddToCart(1, 5);

            cart.ItemsCount.Should().Be(5);
        }

        [Fact]
        public void We_can_specify_shipping_address_for_any_item_inside()
        {
            ShoppingCart cart = ShoppingCart.Empty;
            cart.AddToCart(1, 5, new Address("Ukraine", "Nikolaev", "54003", "Nikolaev", "Levanevskogo 13"));

            cart.Items.First().Address.Should().NotBe(Address.Empty);
        }
    }
}
