using BelissimoCloneWPF.Domain.Commons;

namespace BelissimoCloneWPF.Domain.Entities.Orders
{
    public class FoodOrder : Auditable
    {
        public int FoodId { get; set; }
        public int Count { get; set; }
        public Basket BasketId { get; set; }
    }
}
