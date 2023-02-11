using BelissimoCloneWPF.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelissimoCloneWPF.Domain.Entities.Attachment
{
    public sealed class Attachments : Auditable
    {
        public string FullPath { get; set; }
    }
}
