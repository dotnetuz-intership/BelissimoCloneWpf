using System.ComponentModel.DataAnnotations;

namespace BelissimoCloneWPF.Service.DTOs.Baskets
{
    public class BasketForCreationDTO
    {
        [Required]
        public int TotalPrice { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
