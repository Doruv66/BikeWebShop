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

        private IAccountService service;

        [TempData]
        public string ErrorMessage { get; set; }

        public LoginModel(IAccountService _service)
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
                Account acc = service.GetAccountByEmail(login.Email);
                if(acc != null)
                {
                    if(HashHelper.VerifyPassword(login.Password, acc.salt, acc.password, 1000))
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, acc.email));
                        claims.Add(new Claim("id", $"{acc.id}"));

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
                        return RedirectToPage("/Index");
                    }
                    else
                    {
                        ErrorMessage = "Incorrect Passsword";
                    }
                }
                else
                {
                    ErrorMessage = "Incorrect Login";
                }

            }
            return Page();
        }
    }
}
