namespace EduZoneDomain.Models
{
    public class VideoMaterial : BaseModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

        public Course Course { get; set; } = default!;
    }
}
