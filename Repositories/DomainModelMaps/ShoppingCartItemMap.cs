using FluentNHibernate;
using FluentNHibernate.Mapping;
using GeeksForLess_SampleStore.ShoppingCart.Entities;

namespace GeeksForLess_SampleStore.ShoppingCartRepositories.DomainModelMaps
{
    public class ShoppingCartItemMap : ClassMap<ShoppingCartItem>
    {
        public ShoppingCartItemMap()
        {
            Id(x => x.Id);

            Map(Reveal.Member<ShoppingCartItem>("_cartId")).Column("ShoppingCartId"); //ShoppingCartId

            Component(x => x.Address, y =>
            {
                y.Map(x => x.Country).Nullable();
                y.Map(x => x.State).Nullable();
                y.Map(x => x.City).Nullable();
                y.Map(x => x.ZipCode).Nullable();
                y.Map(x => x.AddressLine).Nullable();
            });

            Component(x => x.Box, y =>
            {
                y.References(x => x.Product).Column("ProductId");
                y.Map(x => x.Quantity);
            });
        }
    }
}
