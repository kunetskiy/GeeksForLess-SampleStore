using FluentNHibernate;
using FluentNHibernate.Mapping;
using GeeksForLess_SampleStore.ShoppingCart.Entities;

namespace GeeksForLess_SampleStore.Repositories.DomainModelMaps
{
    public class ShoppingCartMap : ClassMap<ShoppingCart.Entities.ShoppingCart>
    {
        public ShoppingCartMap()
        {
            //HasOne(x => x.Customer).Constrained();
            Id(x => x.Id).GeneratedBy.Assigned();// Foreign("Customer");
            HasMany<ShoppingCartItem>(Reveal.Member<ShoppingCart.Entities.ShoppingCart>("Items")).Cascade.All();
        }
    }
}
