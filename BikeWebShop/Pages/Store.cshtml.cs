using BikeClassLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeWebShop.Pages
{
    public class StoreModel : PageModel
    {
        public Inventory inventory { get; set; }

        public void OnGet()
        {
            inventory = new Inventory();
        }
    }
}
