using BelissimoCloneWPF.Domain.Entities.Foods;
using BelissimoCloneWPF.Domain.Entities.Orders;

namespace BelissimoCloneWPF.Service.DTOs.Foods
{
    public class FoodOrderForViewDTO
    {
        public int Count { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
        
        public int BasketId { get; set; }
        public Basket Basket { get; set; }
    }
}
