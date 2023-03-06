using System.Collections.Generic;

namespace BelissimoCloneWPF.Service.DTOs.Foods
{
    public class CategoryForViewDTO
    {
        public string Content { get; set; }

        public ICollection<FoodForViewDTO> Foods { get; set; }
    }
}
