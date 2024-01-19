using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Web.Models
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

		public static explicit operator Product(Task<IActionResult> v)
		{
			throw new NotImplementedException();
		}
	}
}
