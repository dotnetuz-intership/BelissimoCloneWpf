using System.IO;

namespace BelissimoCloneWPF.Service.DTOs.Attachment
{
    public class AttachmentForCreationDTO
    {
        public string FullPath { get; set; }

        public Stream File { get; set; }
    }
}
