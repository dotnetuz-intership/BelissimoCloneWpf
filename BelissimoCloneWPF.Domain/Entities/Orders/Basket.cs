using BelissimoCloneWPF.Domain.Commons;
using BelissimoCloneWPF.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelissimoCloneWPF.Domain.Entities.Orders
{
    public sealed class Basket : Auditable
    {
        public int TotalPrice { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<FoodOrder> FoodOrder { get; set; }
    }
}
