using BikeClassLibrary;
using BikeLibrary.BLL;
using BikeLibrary.BLL.Interfaces;
using BikeWebShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace BikeWebShop.Pages
{
    public class CheckoutModel : PageModel
    {
        public double Total { get; set; }

        public IInventory Inventory { get; set; }
        public IAccountService Service { get; }
        public IOrderService Orders { get; }
        [BindProperty]
        public ShippingForm shipping { get; set; }

        public CheckoutModel(IInventory _inventory, IAccountService _service, IOrderService _order)
        {
            Inventory = _inventory;
            Service = _service;
            Orders = _order;
        }

        public void OnGet()
        {
            Cart cart = new Cart();
            cart.SetItems(SessionHelper.GetObjectFromJson(HttpContext.Session, "cart"));
            Total = cart.GetTotalPrice(Inventory);
        }

        public IActionResult OnPost()
        {
            int accid = Convert.ToInt32(User.FindFirst("id").Value);
            Cart cart = new Cart();
            cart.SetItems(SessionHelper.GetObjectFromJson(HttpContext.Session, "cart"));
            if (ModelState.IsValid)
            {
                Account acc = Service.GetAccountByid(accid);
                acc.SetShippingInfo(new ShippingInfo(shipping.Name, shipping.LastName, shipping.PostalCode, shipping.Address));
                Service.SetShippingInformation(acc);
                Orders.AddOrder(new Order(1, "placed", accid, cart.Getitems()));
                cart.Clear();
				SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart.Getitems());
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
