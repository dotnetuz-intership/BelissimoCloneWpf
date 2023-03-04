using System.ComponentModel.DataAnnotations;

namespace BelissimoCloneWPF.Service.DTOs.Foods
{
    public class CategoryForCreationDTO
    {
        [Required]
        public string Content { get; set; }
    }
}
