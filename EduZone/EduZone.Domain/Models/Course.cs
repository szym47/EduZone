namespace EduZoneDomain.Models
{
    public class Course : BaseModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public Category Category { get; set; } = default!;

        public List<VideoMaterial> VideoMaterials { get; set; } = new();

        public List<PdfMaterial> PdfMaterials { get; set; } = new();
    }
}
