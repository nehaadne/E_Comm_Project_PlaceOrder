using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaceOrder.Models
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int ProdId { get; set; }
    }
}
