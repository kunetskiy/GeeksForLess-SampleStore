using FluentNHibernate.Mapping;
using GeeksForLess_SampleStore.ShoppingCart.Entities;

namespace GeeksForLess_SampleStore.ShoppingCartRepositories.DomainModelMaps
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id);
            Map(x => x.Title);
            Map(x => x.Price);
            Map(x => x.CategoryId);
        }
    }
}
