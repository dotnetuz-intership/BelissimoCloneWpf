using BelissimoCloneWPF.Domain.Commons;

namespace BelissimoCloneWPF.Domain.Entities.Baskets
{
    public sealed class Basket: Auditable
    {
        public int UserId { get; set; }
        public int TotalPrice { get; set; }
    }
}
