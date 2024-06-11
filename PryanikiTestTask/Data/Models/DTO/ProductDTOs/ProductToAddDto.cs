namespace PryanikiTestTask.Data.Models.DTO.ProductDTOs
{
    public class ProductToAddDto
    {
        public string Name { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
