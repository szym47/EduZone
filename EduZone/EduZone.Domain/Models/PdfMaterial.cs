namespace EduZoneDomain.Models
{
    public class PdfMaterial : BaseModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string FilePath { get; set; } = string.Empty;

        public Course Course { get; set; } = default!;
    }
}
