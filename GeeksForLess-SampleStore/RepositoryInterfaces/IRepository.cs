using GeeksForLess_SampleStore.Logic.Common;

namespace GeeksForLess_SampleStore.Logic.RepositoryInterfaces
{
    public interface IRepository<T>
        where T : AggregateRoot
    {
        T GetById(int id);
    }
}
