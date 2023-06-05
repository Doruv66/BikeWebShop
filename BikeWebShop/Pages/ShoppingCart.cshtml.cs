using BikeClassLibrary;
using BikeLibrary.BLL;
using BikeLibrary.BLL.Cupons;
using BikeLibrary.DBL;
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

        public AccountService accservice;

        public Inventory inventory;

        public ShoppingCartModel(IBikeRepository bikerep, IAccountRepository accrep)
        {
            inventory = new Inventory(bikerep);
            accservice = new AccountService(accrep);
        }

        public void OnGet()
        {
            cart = SessionHelper.GetObjectFromJson(HttpContext.Session, "cart");
        }

        public IActionResult OnGetAddToCart(int id)
        {
            cart = SessionHelper.GetObjectFromJson(HttpContext.Session, "cart");
            cart.Add(id);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("ShoppingCart");
        }

        public IActionResult OnGetDelete(int id)
        {
            cart = SessionHelper.GetObjectFromJson(HttpContext.Session, "cart");
            cart.Remove(id);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("ShoppingCart");
        }
    }
}
