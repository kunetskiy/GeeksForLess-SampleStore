using System.Collections.Generic;
using System.Linq;
using GeeksForLess_SampleStore.Logic.Entities;
using GeeksForLess_SampleStore.Logic.RepositoryInterfaces;
using NHibernate;
using NHibernate.Linq;

namespace GeeksForLess_SampleStore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        protected readonly ISession _session;
        public ProductRepository(ISession session)
        {
            _session = session;
        }

        public IReadOnlyCollection<Product> GetAll()
        {
            return _session.Query<Product>().ToList();
        }

        public Product GetById(int id)
        {
            return _session.Get<Product>(id);
        }
    }
}
