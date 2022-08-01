using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaceOrder.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Product Price")]
        [Range(minimum: 1, maximum: 100000)]
        public double Price { get; set; }

        [Required(ErrorMessage = "Copany name is required")]
        [Display(Name = "Company name")]
        public string CompanyName { get; set; }
        public int OrderId { get; set; }
        public int CartId { get; set; }
        public int UserId { get; set; }
    }
}
