using BikeClassLibrary;
using BikeLibrary.BLL;
using BikeLibrary.DBL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeWebShop.Pages
{
    public class OrdersModel : PageModel
    {
        public OrderService service { get; private set; }

        public Inventory inventory { get; set; }

        public List<Order> orders { get; private set; }

        public OrdersModel(IOrderRepository orderrep, IBikeRepository bikerep)
        {
            service = new OrderService(orderrep);
            inventory = new Inventory(bikerep);
        }

        public void OnGet()
        {
            orders = service.GetUserOrders(Convert.ToInt16(User.FindFirst("id").Value));
        }

        public IActionResult OnGetReturnRequest(int bikeid, int orderid)
        {
            HttpContext.Session.SetInt32("bikeid", bikeid);
            HttpContext.Session.SetInt32("orderid", orderid);
            return RedirectToPage("ReturnRequest");
        }
    }
}
