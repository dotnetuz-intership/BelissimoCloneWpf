using BelissimoCloneWPF.Domain.Commons;
using BelissimoCloneWPF.Domain.Entities.Users;

namespace BelissimoCloneWPF.Domain.Entities.Baskets
{
    public sealed class Basket: Auditable
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int TotalPrice { get; set; }
    }
}
