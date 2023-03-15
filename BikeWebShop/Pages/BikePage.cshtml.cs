using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BikeClassLibrary;

namespace BikeWebShop.Pages
{
    public class BikePageModel : PageModel
    {
        public Inventory inventory { get; set; }

        public Bike bike { get; set; }

        public void OnGet(int id)
        {
            inventory = new Inventory();
            bike = inventory.GetBike(id);
        }
    }
}
