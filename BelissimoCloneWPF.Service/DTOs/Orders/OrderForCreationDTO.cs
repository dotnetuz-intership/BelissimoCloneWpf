using BelissimoCloneWPF.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BelissimoCloneWPF.Service.DTOs.Orders
{
    public class OrderForCreationDTO
    {
        [Required]
        public string? Location { get; set; }
        [Required]
        public bool IsPayed { get; set; }
        [Required]
        public OrderType OrderType { get; set; }
        [Required]
        public PaymentType PaymentType { get; set; }
        [Required]
        public int BasketId { get; set; }
        [Required]
        public int CourierId { get; set; }
        [Required]
        public int BranchId { get; set; }
    }
}
