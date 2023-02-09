using BelissimoCloneWPF.Domain.Commons;
using BelissimoCloneWPF.Domain.Entities.Baskets;

namespace BelissimoCloneWPF.Domain.Entities.FoodOrders
{
    public class FoodOrder : Auditable
    {
        public int FoodId { get; set; }
        public int Count { get; set; }
        public Basket BasketId { get; set; }
    }
}
