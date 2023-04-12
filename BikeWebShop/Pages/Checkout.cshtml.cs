using BikeClassLibrary;
using BikeLibrary.BLL;
using BikeWebShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace BikeWebShop.Pages
{
    public class CheckoutModel : PageModel
    {
        public double Total { get; set; }

        public Inventory Inventory { get; set; }

        [BindProperty]
        public PlaceOrder orderInfo { get; set; }

        private OrderService orderService;

        public void OnGet()
        {
            List<Item> cart = SessionHelper.GetObjectFromJson(HttpContext.Session, "cart");
            Inventory = new Inventory();
            Total = cart.Sum(i => Inventory.GetBike(i.bikeid).GetPrice() * i.quantity);
        }

        public IActionResult OnPost()
        {
            orderService= new OrderService();
            int accid = Convert.ToInt32(User.FindFirst("id").Value);
            List<Item> cart = SessionHelper.GetObjectFromJson(HttpContext.Session, "cart");
            if (ModelState.IsValid)
            {
                orderService.AddOrder(new Order(1, orderInfo.Name, orderInfo.LastName, orderInfo.Address, orderInfo.PostalCode, "placed", accid, cart));
                cart.Clear();
				SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
