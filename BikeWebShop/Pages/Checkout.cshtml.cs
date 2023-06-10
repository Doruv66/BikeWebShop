using BikeClassLibrary;
using BikeLibrary.BLL;
using BikeLibrary.BLL.Cupons;
using BikeLibrary.BLL.Services;
using BikeLibrary.DBL;
using BikeLibrary.DBL.Interfaces;
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

        public Cart cart { get; set; }
        public OrderService Orders { get; }
        public CouponService coupons { get; set; }
        [BindProperty]
        public ShippingForm shipping { get; set; }

        [BindProperty]
        public string CouponCode { get; set; }

        public CheckoutModel(IBikeRepository bikerep, IAccountRepository accrep, IOrderRepository orderrep, ICouponRepository couponrep)
        {
            Inventory = new Inventory(bikerep);
            Service = new AccountService(accrep);
            Orders = new OrderService(orderrep);
            coupons = new CouponService(couponrep);
        }

        public void OnGet()
        { 
            int accid = Convert.ToInt32(User.FindFirst("id").Value);
            acc = Service.GetAccountByid(accid);
            acc = Service.GetShippingInformation(acc);
            cart = SessionHelper.GetObjectFromJson(HttpContext.Session, "cart");
            Total = cart.GetTotalPrice(Inventory);
        }

        public IActionResult OnPostChangeInfo()
        {
            int accid = Convert.ToInt32(User.FindFirst("id").Value);
            acc = Service.GetAccountByid(accid);
            acc.SetShippingInfo(null);
            cart = SessionHelper.GetObjectFromJson(HttpContext.Session, "cart");
            Total = cart.GetTotalPrice(Inventory);
            return Page();
        }

        public IActionResult OnPostCheckout()
        {
            int accid = Convert.ToInt32(User.FindFirst("id").Value);
            acc = Service.GetAccountByid(accid);
            acc = Service.GetShippingInformation(acc);
            cart = SessionHelper.GetObjectFromJson(HttpContext.Session, "cart");
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

        public IActionResult OnPostApplyCoupon()
        {
            cart = SessionHelper.GetObjectFromJson(HttpContext.Session, "cart");
            try
            {
                var coupon = coupons.ValidateCoupon(CouponCode);
                cart.SetCoupon(coupon);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                return RedirectToPage("Checkout");
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return Page();
        }


    }
}
