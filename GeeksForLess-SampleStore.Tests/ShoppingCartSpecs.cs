using AutoMapper;
using FluentAssertions;
using GeeksForLess_SampleStore.ShoppingCart.Entities;
using GeeksForLess_SampleStore.Tests.AutomapperDtos;
using Xunit;

namespace GeeksForLess_SampleStore.Tests
{
    public class ShoppingCartSpecs
    {
        private IMapper _mapper;
        private Product Bread;
        private Product Pizza;
        private Product TShirt;

        public ShoppingCartSpecs()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ShoppingCartDto, ShoppingCart.Entities.ShoppingCart>();
                cfg.CreateMap<ProductDto, Product>();
            });

            _mapper = config.CreateMapper();

            Bread = _mapper.Map<Product>(new ProductDto { Id = 1, CategoryId = 1, Price = 50, Title = "Bread" });
            Pizza = _mapper.Map<Product>(new ProductDto { Id = 2, CategoryId = 1, Price = 150, Title = "Pizza" });
            TShirt = _mapper.Map<Product>(new ProductDto { Id = 3, CategoryId = 2, Price = 850, Title = "T-shirt" });
        }

        [Fact]
        public void Items_count_and_total_are_valid_after_adding_item_to_cart()
        {
            var cart = _mapper.Map<ShoppingCart.Entities.ShoppingCart>(new ShoppingCartDto { Id = 1 });
            cart.AddToCart(Bread, 5);

            cart.TotalCount.Should().Be(5);
            cart.Total.Should().Be(250);
        }

        [Fact]
        public void When_add_same_product_many_times_ItemsCount_not_changed()
        {
            var cart = _mapper.Map<ShoppingCart.Entities.ShoppingCart>(new ShoppingCartDto { Id = 1 });
            cart.AddToCart(Bread, 5);

            cart.GetAllItems().Count.Should().Be(1);

            cart.AddToCart(Bread, 5);

            cart.GetAllItems().Count.Should().Be(1);
        }

        [Fact]
        public void ItemsCount_total_and_TotalCount_are_correct_after_remove_product_from_cart()
        {
            var cart = _mapper.Map<ShoppingCart.Entities.ShoppingCart>(new ShoppingCartDto { Id = 1 });
            cart.AddToCart(Bread, 5);
            cart.AddToCart(Pizza, 5);
            cart.AddToCart(TShirt, 5);

            cart.GetAllItems().Count.Should().Be(3);
            cart.TotalCount.Should().Be(15);
            cart.Total.Should().Be(50 * 5 + 150 * 5 + 850 * 5);

            cart.RemoveFromCart(2);

            cart.GetAllItems().Count.Should().Be(2);
            cart.TotalCount.Should().Be(10);
            cart.Total.Should().Be(50 * 5 + 850 * 5);
        }

        [Fact]
        public void Cart_is_empty_after_clearing()
        {
            var cart = _mapper.Map<ShoppingCart.Entities.ShoppingCart>(new ShoppingCartDto { Id = 1 });
            cart.AddToCart(Bread, 5);
            cart.AddToCart(Pizza, 5);
            cart.AddToCart(TShirt, 5);

            cart.GetAllItems().Count.Should().Be(3);
            cart.TotalCount.Should().Be(15);
            cart.Total.Should().Be(50 * 5 + 150 * 5 + 850 * 5);

            cart.ClearCart();

            cart.GetAllItems().Count.Should().Be(0);
            cart.TotalCount.Should().Be(0);
            cart.Total.Should().Be(0);
        }
    }
}
