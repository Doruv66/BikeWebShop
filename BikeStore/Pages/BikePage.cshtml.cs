using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BikeClassLibrary;

namespace BikeStore.Pages
{
	public class BikePageModel : PageModel
    {
        public Bike bike { get; set; }

        public void OnGet(int id = 1)
        {
            bike = IndexModel.inventory.GetBike(id);
        }
    }
}
