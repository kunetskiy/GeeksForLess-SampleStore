using System.Collections.Generic;
using GeeksForLess_SampleStore.Logic.Entities;

namespace GeeksForLess_SampleStore.Logic.RepositoryInterfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IReadOnlyCollection<Customer> GetAll();
    }
}
