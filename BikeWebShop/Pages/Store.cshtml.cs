using BikeClassLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeWebShop.Pages
{
    public class StoreModel : PageModel
    {
        public Inventory inventory { get; set; }

        public List<Bike> Catalog { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchedTerm{ get; set; }

        [BindProperty(SupportsGet = true)]
        public int[] Types { get; set; }

        public void OnGet()
        {
            inventory = new Inventory();
            Catalog = inventory.GetBikesBySearch(Types, SearchedTerm);
        }

        public IActionResult OnPost()
        {
            inventory = new Inventory();
            Catalog = inventory.GetBikesBySearch(Types, SearchedTerm);
            return Page();
        }
    }
}
