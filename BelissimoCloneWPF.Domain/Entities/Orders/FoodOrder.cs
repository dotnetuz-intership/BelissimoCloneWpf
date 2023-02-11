using BelissimoCloneWPF.Domain.Commons;
using BelissimoCloneWPF.Domain.Entities.Baskets;
using BelissimoCloneWPF.Domain.Entities.Foods;

namespace BelissimoCloneWPF.Domain.Entities.Orders
{
    public sealed class FoodOrder : Auditable
    {
        public int Count { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
        public int BasketId { get; set; }
        public Basket Basket { get; set; }
    }
}
