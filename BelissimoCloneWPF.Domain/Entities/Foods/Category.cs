using BelissimoCloneWPF.Domain.Commons;
using System.Collections.Generic;

namespace BelissimoCloneWPF.Domain.Entities.Foods
{
    public sealed class Category : Auditable
    {
        public string Content { get; set; }
        public ICollection<Food> Foods { get; set; }
    }
}
