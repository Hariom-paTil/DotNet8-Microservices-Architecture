using Services.ShoppingCartAPI.Models.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.ShoppingCartAPI.Models
{
    public class CartHeader
    {
        [Key]
        public int CartHeaderId { get; set; }

        public string UserId { get; set; }

        public string CouponCode { get; set; }


        [NotMapped] // used to ignore this property when mapping to the database
        // so when we apply a migration, this property will not be created in the database
        public double Discount { get; set; }

        [NotMapped]
        public double CartTotal { get; set; }

    
    }
}
