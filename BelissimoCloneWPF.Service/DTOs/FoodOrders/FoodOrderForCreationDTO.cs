using BelissimoCloneWPF.Domain.Entities.Foods;
using BelissimoCloneWPF.Domain.Entities.Orders;

namespace BelissimoCloneWPF.Service.DTOs.FoodOrders
{
    public class FoodOrderForCreationDTO
    {
        public int Count { get; set; }
        public int FoodId { get; set; }
        public int BasketId { get; set; }
    }
}
