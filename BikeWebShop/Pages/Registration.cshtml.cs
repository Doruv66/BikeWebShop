using BikeLibrary.BLL;
using BikeLibrary.BLL.Interfaces;
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

        private IAccountService service;

        public RegistrationModel(IAccountService _service)
        {
            service = _service;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                byte[] salt = HashHelper.GenerateSalt();
                byte[] hashedpassword = HashHelper.HashPassword(register.Password, salt, 1000);
                Account acc = new Account(1, hashedpassword, salt, register.Email);
                service.AddAccount(acc);
                return RedirectToPage("Login");
            }
            return Page();
        }
    }
}
