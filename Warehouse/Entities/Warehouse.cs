using System.Collections.Generic;
using System.Linq;
using GeeksForLess_SampleStore.Core;

namespace GeeksForLess_SampleStore.Warehouse.Entities
{
    public class Warehouse : AggregateRoot
    {
        protected Warehouse() { }

        private string Title { get; set; }
        private IList<Rack> Racks { get; set; }

        public bool CanYouLockForMe(int productId, int quantity)
        {
            return Racks
                    .Where(pile => pile.Box.ProductId == productId)
                    .Any(pile => pile.Box.AvailableQuantity >= quantity);
        }

        public void LockForMe(int productId, int quantity)
        {
            var productRack = Racks
                        .SingleOrDefault(rack => rack.Box.ProductId == productId);

            var reducedBox = productRack.Box.ReduceQuantity(quantity);
            productRack.ChangeBox(reducedBox);
        }

        public void Delivery(int productId, int quantity)
        {
            var productRack = Racks
                        .SingleOrDefault(rack => rack.Box.ProductId == productId);

            var reducedBox = productRack.Box.IncreaseQuantity(quantity);
            productRack.ChangeBox(reducedBox);
        }
    }
}
