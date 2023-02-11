using BelissimoCloneWPF.Domain.Commons;
using BelissimoCloneWPF.Domain.Entities.Baskets;
using BelissimoCloneWPF.Domain.Enums;

namespace BelissimoCloneWPF.Domain.Entities.Users
{
    public sealed class User : Auditable
    {
        public string  Name { get; set; }
        public string PhoneNumber { get; set; }
        public UserRole Role { get; set; }
    }
}
