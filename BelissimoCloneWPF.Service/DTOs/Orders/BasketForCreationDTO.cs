using System.ComponentModel.DataAnnotations;

namespace BelissimoCloneWPF.Service.DTOs.Orders
{
    public class BasketForCreationDTO
    {
        [Required]
        public int TotalPrice { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
