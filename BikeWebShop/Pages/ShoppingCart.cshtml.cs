using BikeClassLibrary;
using BikeLibrary.BLL;
using BikeLibrary.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace BikeWebShop.Pages
{
    [Authorize]
    public class ShoppingCartModel : PageModel
    {
        public Cart cart { get; set; }   

        public double Total { get; set; }

        public IInventory inventory;

        public ShoppingCartModel(IInventory _inventory)
        {
            inventory = _inventory;
        }

        public void OnGet()
        {
            cart = new Cart();
            cart.SetItems(SessionHelper.GetObjectFromJson(HttpContext.Session, "cart"));
        }

        public IActionResult OnGetAddToCart(int id)
        {
            cart = new Cart();
            cart.SetItems(SessionHelper.GetObjectFromJson(HttpContext.Session, "cart"));
            cart.Add(id);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart.Getitems());
            return RedirectToPage("ShoppingCart");
        }

        public IActionResult OnGetDelete(int id)
        {
            cart = new Cart();
            cart.SetItems(SessionHelper.GetObjectFromJson(HttpContext.Session, "cart"));
            cart.Remove(id);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart.Getitems());
            return RedirectToPage("ShoppingCart");
        }
    }
}
