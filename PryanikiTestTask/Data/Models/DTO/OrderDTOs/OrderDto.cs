using System.ComponentModel.DataAnnotations.Schema;

namespace PryanikiTestTask.Data.Models.DTO.OrderDTOs
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = null!;
        public double SumPrice { get; set; }
    }
}
