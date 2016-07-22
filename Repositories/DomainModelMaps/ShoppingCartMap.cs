using FluentNHibernate.Mapping;
using GeeksForLess_SampleStore.Logic.Entities;

namespace GeeksForLess_SampleStore.Repositories.DomainModelMaps
{
    public class ShoppingCartMap : ClassMap<ShoppingCart>
    {
        public ShoppingCartMap()
        {
            //HasOne(x => x.Customer).Constrained();
            Id(x => x.Id).GeneratedBy.Assigned();// Foreign("Customer");

            HasMany(x => x.Items).Cascade.All();
        }
    }
}
