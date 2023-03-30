using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BikeWebShop.ViewModels
{
    public class Login
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
