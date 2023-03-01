using BelissimoCloneWPF.Service.DTOs.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelissimoCloneWPF.Service.DTOs.Baskets
{
    public class BasketForViewDTO
    {
        public int TotalPrice { get; set; }
        public int UserId { get; set; }
        public ICollection<FoodOrderForViewDTO> FoodOrders { get; set; }
    }
}
