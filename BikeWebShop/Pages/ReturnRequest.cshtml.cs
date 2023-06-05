using BikeClassLibrary;
using BikeLibrary.BLL;
using BikeLibrary.DBL;
using BikeLibrary.DBL.Interfaces;
using BikeWebShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeWebShop.Pages
{
    [Authorize]
    public class ReturnRequestModel : PageModel
    {
        public Inventory inventory { get; set; }

        public ReturnService returnService { get; set; }

        public OrderService orderService { get; set; }

        public Bike bike { get; set; }

        public int order { get; set; }

        [BindProperty]
        public ReturnRequest request { get; set; }

        public ReturnRequestModel(IBikeRepository bikerep, IReturnRepository returns, IOrderRepository orderrep)
        {
            returnService = new ReturnService(returns);
            inventory = new Inventory(bikerep);
            orderService = new OrderService(orderrep);
        }

        public void OnGet()
        {
        }

        public void OnPostReturnRequest()
        {
            bike = inventory.GetBike(Convert.ToInt32(Request.Form["bikeid"]));
            order = Convert.ToInt32(Request.Form["orderid"]);
        }

        public IActionResult OnPostReturnItem(int id, int orderid)
        {
            if (ModelState.IsValid)
            {
                returnService.AddReturn(new Return(1, request.Reason, request.Comment, id, orderid, DateTime.Now), orderService);
                return RedirectToPage("Orders");
            }
            return RedirectToPage("ReturnRequest");
        }
    }
}
