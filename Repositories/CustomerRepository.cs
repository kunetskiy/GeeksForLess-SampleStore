using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeeksForLess_SampleStore.Logic.Entities;
using GeeksForLess_SampleStore.Logic.RepositoryInterfaces;
using NHibernate;
using NHibernate.Linq;

namespace GeeksForLess_SampleStore.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
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
