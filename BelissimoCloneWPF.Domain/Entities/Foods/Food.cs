using BelissimoCloneWPF.Domain.Commons;
using BelissimoCloneWPF.Domain.Entities.Attachment;

namespace BelissimoCloneWPF.Domain.Entities.Foods
{
    public sealed class Food : Auditable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int AttachmentsId { get; set; }
        public Attachments Attachment { get; set; }
    }
}
