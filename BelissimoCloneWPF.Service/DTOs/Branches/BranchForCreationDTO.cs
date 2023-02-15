using System.ComponentModel.DataAnnotations;
namespace BelissimoCloneWPF.Service.DTOs.Branches
{
    public class BranchForCreationDTO
    {
        [Required]
        public string Operators { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
    }
}
