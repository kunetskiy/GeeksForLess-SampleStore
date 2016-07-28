using GeeksForLess_SampleStore.Core;
using NHibernate;

namespace GeeksForLess_SampleStore.ShoppingCartRepositories
{
    public abstract class Repository<T>
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
