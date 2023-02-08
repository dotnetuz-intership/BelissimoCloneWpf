using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelissimoCloneWPF.Domain.Entities.Baskets
{
    public sealed class Basket: Auditable
    {
        public int UserId { get; set; }
        public int TotalPrice { get; set; }
    }
}
