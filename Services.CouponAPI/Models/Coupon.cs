using System.ComponentModel.DataAnnotations;

namespace Services.CouponAPI.Models
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }

        [Required]
        public string CouponCode { get; set; }
        
        [Required] // used of this attribute is to make sure that the DiscountAmount is
                   // required and cannot be null
        public double DiscountAmount { get; set; }

        public int MinAmount { get; set; }
    }
}
