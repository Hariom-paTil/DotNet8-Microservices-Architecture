namespace Services.CouponAPI.Models.DTO
{
    public class CouponResponceDto
    {
        public object? Result { get; set; }

        public bool IsSuccess { get; set; } = true;

        public string? Message { get; set; } = string.Empty;


    }
}
