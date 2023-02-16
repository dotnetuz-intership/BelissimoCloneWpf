using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelissimoCloneWPF.Service.DTOs.Foods
{
    public class CategoryForCreationDTO
    {
        [Required]
        public string Context { get; set; }
    }
}
