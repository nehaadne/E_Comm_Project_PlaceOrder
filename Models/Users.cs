using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaceOrder.Models
{
    [Table("Users")]
    public class Users
    {
        
            [Key]
            public int Id { get; set; }
            [Required(ErrorMessage = "Name required")]
            [Display(Name = "Name")]
            public string Name { get; set; }
           [Required(ErrorMessage = "Email is required")]
           [DataType(DataType.EmailAddress)]
           public string Emailid { get; set; }

           [Required(ErrorMessage = "Password is required")]
           [DataType(DataType.Password)]
           [Display(Name = "Enter Password")]
           public string Password { get; set; }
           [Display(Name = "RoleId")]
           public int RoleId { get; set; }
    }

}


