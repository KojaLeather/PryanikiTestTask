using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PryanikiTestTask.Data.Models
{
    [Table("orders", Schema = "PryanikiTestTask")]
    public class Order
    {
        [Key]
        [Column("orderId")]
        public int OrderId { get; set; }
        [Column("orderDate")]
        public DateTime OrderDate { get; set; }
        [Column("status")]
        public string Status { get; set; } = null!;
        [Column("sumPrice")]
        public double SumPrice { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
