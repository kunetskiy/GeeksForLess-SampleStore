using FluentNHibernate.Mapping;
using GeeksForLess_SampleStore.ShoppingCart.Entities;

namespace GeeksForLess_SampleStore.ShoppingCartRepositories.DomainModelMaps
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Id(x => x.Id);
            Map(x => x.Title);
        }
    }
}
