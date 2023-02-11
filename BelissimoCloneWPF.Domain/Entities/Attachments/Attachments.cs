using BelissimoCloneWPF.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelissimoCloneWPF.Domain.Entities.Attachments
{
    public class Attachments : Auditable
    {
        public string FullPath { get; set; }
    }
}
