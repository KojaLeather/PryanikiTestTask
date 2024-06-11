using PryanikiTestTask.Data.Models.DTO.ProductDTOs;

namespace PryanikiTestTask.Data.Models.DTO.OrderDTOs
{
    public class CreateOrderDto
    {
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = null!;
        public ICollection<ProductsOrderedDto> Products { get; set; }
    }
}
