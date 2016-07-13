using GeeksForLess_SampleStore.Logic.Common;

namespace GeeksForLess_SampleStore.Logic.Entities
{
    public class Category : Entity
    {
        protected Category()
        { }

        public virtual string Title { get; }
    }
}
