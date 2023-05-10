using System.ComponentModel.DataAnnotations;

namespace BikeWebShop.ViewModels
{
    public class ReturnRequest
    {
        [Required]
        public string Reason { get; set; }

        [Required]
        public string Comment { get; set; }
    }
}
