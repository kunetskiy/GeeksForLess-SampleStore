using System.Collections.Generic;
using System.Linq;
using GeeksForLess_SampleStore.ShoppingCart.Entities;
using NHibernate;
using NHibernate.Linq;

namespace GeeksForLess_SampleStore.ShoppingCartRepositories
{
    public class CustomerRepository : Repository<Customer>
    {
        public CustomerRepository(ISession session) : base(session)
        {
        }

        public IReadOnlyCollection<Customer> GetAll()
        {
            return _session.Query<Customer>().ToList();
        }
    }
}
