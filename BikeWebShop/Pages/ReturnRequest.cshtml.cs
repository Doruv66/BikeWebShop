using BikeClassLibrary;
using BikeLibrary.BLL;
using BikeLibrary.BLL.Interfaces;
using BikeLibrary.DBL;
using BikeLibrary.DBL.Interfaces;
using BikeWebShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeWebShop.Pages
{
    public class ReturnRequestModel : PageModel
    {
        public Inventory inventory { get; set; }

        public ReturnService returnService { get; set; }

        public Bike bike { get; set; }

        public int order { get; set; }

        [BindProperty]
        public ReturnRequest request { get; set; }

        public ReturnRequestModel(IBikeRepository bikerep, IReturnRepository returns)
        {
            returnService = new ReturnService(returns);
            inventory = new Inventory(bikerep);
        }

        public void OnGet(int id, int orderid)
        {
            bike = inventory.GetBike(id);
            order = orderid;
        }

        public IActionResult OnPostReturnItem(int id, int orderid)
        {
            if (ModelState.IsValid)
            {
                returnService.AddReturn(new Return(1, request.Reason, request.Comment, id, orderid));
                return RedirectToPage("Orders");
            }
            return Page();
        }
    }
}
