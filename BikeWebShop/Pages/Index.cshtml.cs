using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BikeClassLibrary;
using BikeLibrary.BLL.Interfaces;

namespace BikeWebShop.Pages
{
	public class IndexModel : PageModel
	{
		public IInventory inventory { get; set; }

		public IndexModel(IInventory _inventory)
		{
			inventory = _inventory;
		}

		public void OnGet()
		{
		}
	}
}