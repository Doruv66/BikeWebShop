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

        private AccountService service;


        public string ErrorMessage { get; set; }

        public RegistrationModel(IAccountRepository accrep)
        {
            service = new AccountService(accrep);
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    byte[] salt = HashHelper.GenerateSalt();
                    byte[] hashedpassword = HashHelper.HashPassword(register.Password, salt, 8000);
                    Account acc = new Account(1, hashedpassword, salt, register.Email);
                    service.AddAccount(acc);
                    return RedirectToPage("Login");
                }
            }
            catch(ArgumentException ex)
            {
                ErrorMessage = ex.Message;
            }
            return Page();
        }
    }
}
