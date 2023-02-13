namespace BelissimoCloneWPF.Service.DTOs.Foods
{
    public class FoodForCreationDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public int AttachmentId { get; set; }
    }
}
