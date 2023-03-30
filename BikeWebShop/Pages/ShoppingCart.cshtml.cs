using BikeClassLibrary;
using BikeLibrary.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace BikeWebShop.Pages
{
    [Authorize]
    public class ShoppingCartModel : PageModel
    {
        public List<Item> cart { get; set; }   

        public double Total { get; set; }

        public Inventory inventory;


        public void OnGet()
        {
            cart = SessionHelper.GetObjectFromJson(HttpContext.Session, "cart");
            inventory = new Inventory();
            if(cart != null)
            {
                Total = cart.Sum(i => inventory.GetBike(i.bikeid).GetPrice() * i.quantity);

            }
            else
            {
                Total = 0;
            }
        }

        public IActionResult OnGetAddToCart(int id)
        {
            cart = SessionHelper.GetObjectFromJson(HttpContext.Session, "cart");
            if (cart == null)
            {
                cart = new List<Item>();
                cart.Add(new Item(id, 1));
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                int index = Exists(cart, id);
                if (index == -1)
                {
                    cart.Add(new Item(id, 1));
                }
                else
                {
                    cart[index].quantity++;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToPage("ShoppingCart");
        }

        public IActionResult OnGetDelete(int id)
        {
            cart = SessionHelper.GetObjectFromJson(HttpContext.Session, "cart");
            int index = Exists(cart, id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("ShoppingCart");
        }

        public IActionResult OnPostUpdate(int[] quantity, int[] bikeid)
        {
            cart = SessionHelper.GetObjectFromJson(HttpContext.Session, "cart");
            for (var i = 0; i < quantity.Length; i++)
            {
                int id = bikeid[i];
                int qty = quantity[i];
                int index = Exists(cart, id);
                cart[index].quantity = qty;
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("ShoppingCart");
        }

        private int Exists(List<Item> cart, int id)
        {
            for (var i = 0; i < cart.Count; i++)
            {
                if (cart[i].bikeid == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
