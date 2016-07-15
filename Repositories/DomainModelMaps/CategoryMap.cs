using FluentNHibernate.Mapping;
using GeeksForLess_SampleStore.Logic.Entities;

namespace GeeksForLess_SampleStore.Repositories.DomainModelMaps
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
