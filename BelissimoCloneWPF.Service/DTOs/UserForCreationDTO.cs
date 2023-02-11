using System.ComponentModel.DataAnnotations;

namespace BelissimoCloneWPF.Service.DTOs
{
    public class UserForCreationDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
