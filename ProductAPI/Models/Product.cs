using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public string? ProductDescription { get; set; }
        
        public string ProductCategory { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
    }
}
