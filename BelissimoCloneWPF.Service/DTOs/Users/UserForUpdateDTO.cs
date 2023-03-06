using System.ComponentModel.DataAnnotations;

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
