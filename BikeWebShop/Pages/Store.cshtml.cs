using BikeClassLibrary;
using BikeLibrary.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeWebShop.Pages
{
    public class StoreModel : PageModel
    {
        public IInventory inventory { get; set; }

        public List<Bike> Catalog { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchedTerm{ get; set; }

        [BindProperty(SupportsGet = true)]
        public int[] Types { get; set; }

        public StoreModel(IInventory _inventory)
        {
            inventory = _inventory;
        }
        public void OnGet()
        {
            Catalog = inventory.GetBikesBySearch(Types, SearchedTerm);
        }

        public IActionResult OnPost()
        {
            Catalog = inventory.GetBikesBySearch(Types, SearchedTerm);
            return Page();
        }
    }
}
