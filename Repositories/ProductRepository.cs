using System.Collections.Generic;
using System.Linq;
using GeeksForLess_SampleStore.Logic.Entities;
using GeeksForLess_SampleStore.Logic.RepositoryInterfaces;
using NHibernate;
using NHibernate.Linq;

namespace GeeksForLess_SampleStore.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ISession session) : base(session)
        {
        }

        public IReadOnlyCollection<Product> GetAll()
        {
            return _session.Query<Product>().ToList();
        }
    }
}
