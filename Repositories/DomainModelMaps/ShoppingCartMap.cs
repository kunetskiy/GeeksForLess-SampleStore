using FluentNHibernate.Mapping;
using GeeksForLess_SampleStore.Logic.Entities;

namespace GeeksForLess_SampleStore.Repositories.DomainModelMaps
{
    public class ShoppingCartMap : ClassMap<ShoppingCart>
    {
        public ShoppingCartMap()
        {
            Id(x => x.Id);

            References(x => x.Items).Not.LazyLoad();
        }
    }
}
