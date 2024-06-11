using System.ComponentModel.DataAnnotations.Schema;

namespace PryanikiTestTask.Data.Models.DTO.ProductDTOs
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Price { get; set; }
        public int Quanity { get; set; }
    }
}
