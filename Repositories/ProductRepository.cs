using System.Collections.Generic;
using System.Linq;
using GeeksForLess_SampleStore.ShoppingCart.Entities;
using NHibernate;
using NHibernate.Linq;

namespace GeeksForLess_SampleStore.ShoppingCartRepositories
{
    public class ProductRepository : Repository<Product>
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
