using FluentNHibernate.Mapping;
using GeeksForLess_SampleStore.Logic.Entities;

namespace GeeksForLess_SampleStore.Repositories.DomainModelMaps
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

            HasOne(x => x.Cart).Not.LazyLoad();
        }
    }
}
