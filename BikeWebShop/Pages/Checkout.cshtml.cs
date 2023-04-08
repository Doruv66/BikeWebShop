using BikeClassLibrary;
using BikeLibrary.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeWebShop.Pages
{
    public class CheckoutModel : PageModel
    {
        public double Total { get; set; }

        public Inventory Inventory { get; set; }

        public void OnGet()
        {
            List<Item> cart = SessionHelper.GetObjectFromJson(HttpContext.Session, "cart");
            Inventory = new Inventory();
            Total = cart.Sum(i => Inventory.GetBike(i.bikeid).GetPrice() * i.quantity);
        }
    }
}
