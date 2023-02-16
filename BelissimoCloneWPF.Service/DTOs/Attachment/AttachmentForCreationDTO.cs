using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelissimoCloneWPF.Service.DTOs.Attachment
{
    public class AttachmentForCreationDTO
    {
        public string FullPath { get; set; }

        public Stream Stream { get; set; }
    }
}
