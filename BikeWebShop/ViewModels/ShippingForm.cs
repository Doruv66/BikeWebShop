using System.ComponentModel.DataAnnotations;

namespace BikeWebShop.ViewModels
{
    public class ShippingForm
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Postal code is required")]
        [RegularExpression(@"^[1-9][0-9]{3}\s?[a-zA-Z]{2}$", ErrorMessage = "Invalid postal code format")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
    }
}
