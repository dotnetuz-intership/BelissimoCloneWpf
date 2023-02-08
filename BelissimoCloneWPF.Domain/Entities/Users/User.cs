using BelissimoCloneWPF.Domain.Commons;
using BelissimoCloneWPF.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelissimoCloneWPF.Domain.Entities.Users
{
    public sealed class User : Auditable
    {
        public string  Name { get; set; }
        public string PhoneNumber { get; set; }

        public UserRole Role { get; set; }

    }
}
