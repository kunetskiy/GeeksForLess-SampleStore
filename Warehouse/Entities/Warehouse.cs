using System.Collections.Generic;
using GeeksForLess_SampleStore.Core;

namespace GeeksForLess_SampleStore.Warehouse.Entities
{
    public class Warehouse : AggregateRoot
    {
        private IList<ProductPile> Piles { get; set; }
    }
}
