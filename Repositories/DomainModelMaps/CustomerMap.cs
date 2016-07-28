using FluentNHibernate;
using FluentNHibernate.Mapping;
using GeeksForLess_SampleStore.ShoppingCart.Entities;

namespace GeeksForLess_SampleStore.ShoppingCartRepositories.DomainModelMaps
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.Id);

            Component(x => x.VisitingCard, y =>
            {
                y.Map(x => x.FirstName);
                y.Map(x => x.LastName);
            });

            HasOne<ShoppingCart.Entities.ShoppingCart>(Reveal.Member<Customer>("_cart")).Cascade.All();
        }
    }
}
