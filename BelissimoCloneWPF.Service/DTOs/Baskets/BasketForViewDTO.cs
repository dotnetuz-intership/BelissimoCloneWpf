using BelissimoCloneWPF.Service.DTOs.Foods;
using System.Collections.Generic;

namespace BelissimoCloneWPF.Service.DTOs.Baskets
{
    public class BasketForViewDTO
    {
        public int TotalPrice { get; set; }
        public int UserId { get; set; }
        public ICollection<FoodOrderForViewDTO> FoodOrders { get; set; }
    }
}
