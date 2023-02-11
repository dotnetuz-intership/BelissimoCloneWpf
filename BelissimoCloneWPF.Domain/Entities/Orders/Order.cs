using BelissimoCloneWPF.Domain.Commons;
using BelissimoCloneWPF.Domain.Entities.Baskets;
using BelissimoCloneWPF.Domain.Entities.Branches;
using BelissimoCloneWPF.Domain.Entities.Users;
using BelissimoCloneWPF.Domain.Enums;

namespace BelissimoCloneWPF.Domain.Entities.Orders
{
    public class Order : Auditable
    {
        public string Location { get; set; }
        public bool IsPayed { get; set; }
        public OrderType OrderTypes { get; set; }
        public PaymentType PaymentTypes { get; set; }
        public int BasketId { get; set; }
        public Basket Basket { get; set; }   
        public int CourierId { get; set; }
        public User Courier { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

    }
}
