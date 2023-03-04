using BelissimoCloneWPF.Domain.Entities.Attachment;

namespace BelissimoCloneWPF.Service.DTOs.Foods
{
    public class FoodForViewDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public int AttachmentsId { get; set; }
        public Attachments Attachment { get; set; }
    }
}
