using BelissimoCloneWPF.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BelissimoCloneWPF.Domain.Entities.Foods
{
    public sealed class Food:Auditable
    {
        public string  Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int AttachmentId { get; set; }


    }
}
