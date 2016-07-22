using FluentAssertions;
using GeeksForLess_SampleStore.Logic.Entities;
using Xunit;
using static GeeksForLess_SampleStore.Logic.Entities.Product;

namespace GeeksForLess_SampleStore.Tests
{
    public class ShoppingCartSpecs
    {
        [Fact]
        public void Items_count_inside_correct_after_adding_new_one()
        {
            ShoppingCart cart = ShoppingCart.Empty;

            cart.AddToCart(Bread, 5);

            cart.ItemsCount.Should().Be(5);
        }

        [Fact]
        public void Total_correct_after_adding_new_one()
        {
            ShoppingCart cart = ShoppingCart.Empty;

            cart.AddToCart(Bread, 5);

            cart.Total.Should().Be(Bread.Price * 5);
        }

        //[Fact]
        //public void We_can_specify_shipping_address_for_any_item_inside()
        //{
        //    ShoppingCart cart = ShoppingCart.Empty;

        //    cart.AddToCart(Bread, 5, new Address("Ukraine", "Nikolaev", "54003", "Nikolaev", "Levanevskogo 13"));
        //    cart.AddToCart(Bread, 5, new Address("Ukraine", "Nikolaev", "54003", "Nikolaev", "Kolodeznaya 21"));

        //    cart.Items.First().Address.Should().NotBe(Address.Empty);
        //    cart.Items.First().Address.Should().NotBe(cart.Items.Last().Address);
        //}

        [Fact]
        public void Cart_is_empty_after_clearing()
        {
            ShoppingCart cart = ShoppingCart.Empty;

            cart.AddToCart(Bread, 5);
            cart.AddToCart(Bread, 5);
            cart.ClearCart();

            cart.ItemsCount.Should().Be(0);
        }
    }
}
