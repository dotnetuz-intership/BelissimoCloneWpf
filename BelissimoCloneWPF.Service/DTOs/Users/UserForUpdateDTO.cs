using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelissimoCloneWPF.Service.DTOs.Users
{
    public class UserForUpdateDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
