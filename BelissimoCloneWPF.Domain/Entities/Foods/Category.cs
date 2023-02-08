using BelissimoCloneWPF.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelissimoCloneWPF.Domain.Entities.Foods
{
    public sealed class Category:Auditable
    {
        public string Content { get; set; }
    }
}
