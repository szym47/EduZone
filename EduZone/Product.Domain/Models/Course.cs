using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProductDomain.Models
{
    public class Course : BaseModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Ean { get; set; } = string.Empty;

        [Precision(18, 2)]
        [Range(0, 10000)]
        public decimal Price { get; set; }

        [Range(0, 100000)]
        public int Stock { get; set; } = 0;

        [StringLength(50)]
        public string Sku { get; set; } = string.Empty;

        [Required]
        public Category Category { get; set; } = default!;
    }
}
