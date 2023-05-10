﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BikeClassLibrary;
using BikeLibrary.BLL.Interfaces;
using BikeLibrary.DBL;

namespace BikeWebShop.Pages
{
	public class IndexModel : PageModel
	{
		public Inventory inventory { get; set; }

		public IndexModel(IBikeRepository bikerep)
		{
			inventory = new Inventory(bikerep);
		}

		public void OnGet()
		{
		}
	}
}