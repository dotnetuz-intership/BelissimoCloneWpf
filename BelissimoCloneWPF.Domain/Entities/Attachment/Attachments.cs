using BelissimoCloneWPF.Domain.Commons;

namespace BelissimoCloneWPF.Domain.Entities.Attachment
{
    public sealed class Attachments : Auditable
    {
        public string FullPath { get; set; }
    }
}
