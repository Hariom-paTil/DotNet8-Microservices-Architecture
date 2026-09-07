namespace Services.ProductAPI.Model.DTO
{
    public class ResponceDto
    {
         public object? Result { get; set; } // return result of the operation, can be any type of object

        public bool IsSuccess { get; set; } = true;

        public string? Message { get; set; } = string.Empty;

    }
}
