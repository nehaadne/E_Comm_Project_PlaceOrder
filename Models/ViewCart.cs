using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaceOrder.Models
{
    [Table("Cart")]

    public class ViewCart
    {
        [Key]
        public int CartId { get; set; }
        public int ProdId { get; set; }
        public int UserId { get; set; }
    }
}
