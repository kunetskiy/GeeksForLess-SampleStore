using NHibernate;

namespace GeeksForLess_SampleStore.Logic.Common
{
    public abstract class Repository<T>
        where T : AggregateRoot
    {
        private readonly ISession _session;

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
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(aggregateRoot);
                transaction.Commit();
            }
        }
    }
}
