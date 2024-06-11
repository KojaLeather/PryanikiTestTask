using System.ComponentModel.DataAnnotations.Schema;

namespace PryanikiTestTask.Data.Models
{
    [Table("product_order", Schema = "PryanikiTestTask")]
    public class ProductOrder
    {
        [Column("orderId")]
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        [Column("productId")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        [Column("Quantity")]
        public int Quantity { get; set; }
    }
}
