using GeeksForLess_SampleStore.Logic.Common;
using GeeksForLess_SampleStore.Logic.RepositoryInterfaces;
using NHibernate;

namespace GeeksForLess_SampleStore.Repositories
{
    public abstract class Repository<T> : IRepository<T>
        where T : AggregateRoot
    {
        protected readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public T GetById(int id)
        {
            return _session.Get<T>(id);
        }

        public void Save(T aggregateRoot)
        {
            _session.SaveOrUpdate(aggregateRoot);
        }
    }
}
