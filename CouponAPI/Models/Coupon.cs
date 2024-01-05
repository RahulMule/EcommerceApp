using System.ComponentModel.DataAnnotations;

namespace CouponAPI.Models
{
    public class Coupon
    {
        [Key]
        public int CouponID { get; set; }
        [Required]
        public string? CouponName { get; set; } 
        [Required]
        public int Discount { get; set; }
        public int MinAmount { get; set; }  
    }
}
