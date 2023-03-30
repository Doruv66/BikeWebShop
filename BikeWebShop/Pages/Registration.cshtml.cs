using BikeLibrary.BLL;
using BikeWebShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeWebShop.Pages
{
    public class RegistrationModel : PageModel
    {
        [BindProperty]
        public Registration register { get; set; }

        private CycleService service;

        public void OnGet()
        {
            service = new CycleService();
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                service = new CycleService();
                byte[] salt = HashHelper.GenerateSalt();
                byte[] hashedpassword = HashHelper.HashPassword(register.Password, salt, 1000);
                Account acc = new Account(1, hashedpassword, salt, register.Email);
                service.AddAccount(acc);
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
