using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PryanikiTestTask.Data.Models
{
    [Table("products", Schema = "PryanikiTestTask")]
    public class Product
    {
        [Key]
        [Column("productId")]
        public int ProductId { get; set; }
        [Column("name")]
        public string Name { get; set; } = null!;
        [Column("category")]
        public string Category { get; set; } = null!;
        [Column("description")]
        public string Description { get; set; } = null!;
        [Column("price")]
        public double Price { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        public ICollection<ProductOrder>? ProductOrders { get; set; }
    }
}
