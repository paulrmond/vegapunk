using System.ComponentModel.DataAnnotations;

namespace Vegapunk.Services.CouponAPI.Models
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }
        [Required]
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmouint { get; set; }
    }
}
