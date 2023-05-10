using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BikeWebShop.ViewModels;
using BikeLibrary.BLL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using BikeLibrary.BLL.Interfaces;

namespace BikeWebShop.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login login { get; set; }

        private AccountService service;

        [TempData]
        public string errorMessage { get; set; }

        public LoginModel(IAccountRepository accrep)
        {
            service = new AccountService(accrep);
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                Account acc = service.GetAccountByEmail(login.Email);
                if(acc != null)
                {
                    if(HashHelper.VerifyPassword(login.Password, acc.GetSalt(), acc.GetPassword(), 8000))
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, acc.GetEmail()));
                        claims.Add(new Claim("id", $"{acc.GetId()}"));

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
                        return RedirectToPage("/Index");
                    }
                    else
                    {
                        errorMessage = "Incorrect Passsword";
                    }
                }
                else
                {
                    errorMessage = "Incorrect Login";
                }

            }
            return Page();
        }
    }
}
