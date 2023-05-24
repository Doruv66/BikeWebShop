using BikeClassLibrary;
using BikeLibrary.BLL;
using BikeLibrary.DBL;
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
        public AccountService Service { get; }
        public Account acc { get; set; }
        public OrderService Orders { get; }
        [BindProperty]
        public ShippingForm shipping { get; set; }

        public CheckoutModel(IBikeRepository bikerep, IAccountRepository accrep, IOrderRepository orderrep)
        {
            Inventory = new Inventory(bikerep);
            Service = new AccountService(accrep);
            Orders = new OrderService(orderrep);
        }

        public void OnGet()
        {
            int accid = Convert.ToInt32(User.FindFirst("id").Value);
            acc = Service.GetAccountByid(accid);
            acc = Service.GetShippingInformation(acc);
            Cart cart = SessionHelper.GetObjectFromJson(HttpContext.Session, "cart");
            Total = cart.GetTotalPrice(Inventory);
        }

        public IActionResult OnPostChangeInfo()
        {
            int accid = Convert.ToInt32(User.FindFirst("id").Value);
            acc = Service.GetAccountByid(accid);
            acc.SetShippingInfo(null);
            Cart cart = SessionHelper.GetObjectFromJson(HttpContext.Session, "cart");
            Total = cart.GetTotalPrice(Inventory);
            return Page();
        }

        public IActionResult OnPostCheckout()
        {
            int accid = Convert.ToInt32(User.FindFirst("id").Value);
            acc = Service.GetAccountByid(accid);
            acc = Service.GetShippingInformation(acc);
            Cart cart = SessionHelper.GetObjectFromJson(HttpContext.Session, "cart");
            if (ModelState.IsValid)
            {
                    Service.SetShippingInformation(accid, new ShippingInfo(shipping.Name, shipping.LastName, shipping.PostalCode, shipping.Address));
                    acc = Service.GetShippingInformation(acc);
                    Orders.AddOrder(new Order(1, "placed", accid, cart.Getitems(), DateTime.Now, acc.GetShippingInfo()), Inventory);
                    cart.Clear();
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                    return RedirectToPage("Orders");
            }
            if (acc.GetShippingInfo() != null)
            {
                    Orders.AddOrder(new Order(1, "placed", accid, cart.Getitems(), DateTime.Now, acc.GetShippingInfo()), Inventory);
                    cart.Clear();
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                    return RedirectToPage("Orders");
            }
            return Page();
        }
            
    }
}
