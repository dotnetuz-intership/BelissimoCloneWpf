using BelissimoCloneWPF.Service.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelissimoCloneWPF.Service.DTOs.Users
{
    public class UserForViewDTO
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
