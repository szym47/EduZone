using System.ComponentModel.DataAnnotations;

namespace ProductDomain.Models
{
    public class Category : BaseModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;
    }
}
