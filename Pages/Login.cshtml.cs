using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AT_C__2.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnPost()
        {
            if (Username != "" && Password != "")
            {
                var claims = new[] { new Claim(ClaimTypes.Name, Username) };
                var identity = new ClaimsIdentity(claims, "CookieAuth");
                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync("CookieAuth", principal);
                return RedirectToPage("/Clientes/Index");
            }
            ModelState.AddModelError("", "Usuário ou senha inválidos.");
            return Page();
        }
    }
}
