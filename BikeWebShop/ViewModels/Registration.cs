using System.ComponentModel.DataAnnotations;

namespace BikeWebShop.ViewModels
{
    public class Registration
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(30, ErrorMessage = "Must be between 5 and 50 characters", MinimumLength = 5)]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "passwords did not match")]
        public string ConfirmPassword { get; set;}
    }
}
