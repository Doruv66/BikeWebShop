using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BikeClassLibrary;



namespace BikeStore.Pages
{
	public class StoreModel : PageModel
    {
        public Inventory invetory;
      
        public void OnGet()
        {
            invetory = new Inventory();
            invetory.MockBikes();
        }
    }
}
