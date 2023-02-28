using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelissimoCloneWPF.Service.DTOs.Foods
{
    public class CategoryForViewDTO
    {
        public string Content { get; set; }

        public ICollection<FoodForViewDTO> Foods { get; set; }
    }
}
