using PryanikiTestTask.Data.Models.DTO.ProductDTOs;

namespace PryanikiTestTask.Data.Models.DTO.OrderDTOs
{
    public class OrderWithProductsDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = null!;
        public double SumPrice { get; set; }
        public ICollection<ProductDto> ProductsDto { get; set; }
    }
}
