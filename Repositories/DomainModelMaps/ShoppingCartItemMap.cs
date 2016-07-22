using FluentNHibernate.Mapping;
using GeeksForLess_SampleStore.Logic.Entities;

namespace GeeksForLess_SampleStore.Repositories.DomainModelMaps
{
    public class ShoppingCartItemMap : ClassMap<ShoppingCartItem>
    {
        public ShoppingCartItemMap()
        {
            Id(x => x.Id);

            References(x => x.Cart).Column("ShoppingCartId");

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
