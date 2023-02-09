using BelissimoCloneWPF.Domain.Commons;
using BelissimoCloneWPF.Domain.Entities.Branches;
using BelissimoCloneWPF.Domain.Entities.Users;
using BelissimoCloneWPF.Domain.Enums;

namespace BelissimoCloneWPF.Domain.Entities.Orders
{
    public class Order : Auditable
    {
        public string Location { get; set; }
        public bool IsPayed { get; set; }
        public Basket BasketId { get; set; }
        public OrderType OrderTypes { get; set; }
        public User CourierId { get; set; }
        public PaymentType PaymentTypes { get; set; }
        public Branch BranchId { get; set; }

    }
}
