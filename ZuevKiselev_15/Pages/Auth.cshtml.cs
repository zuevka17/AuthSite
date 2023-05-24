using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Crypto.Operators;
using System.Security.Claims;
using ZuevKiselev_15.Models;

namespace ZuevKiselev_15.Pages
{
    public class AuthModel : BasePageModel
    {
        public async Task<IActionResult> OnPost(string? returnUrl)
        {
            var form = HttpContext.Request.Form;

            if (!form.ContainsKey("Login") || !form.ContainsKey("Password"))
                return BadRequest("Login и/или пароль не установлены");

            string Login = form["Login"];
            string Password = form["Password"];

            var db = new Is5110Context();

            User? user = db.Users.FirstOrDefault(p => p.Login == Login && p.Password == Password);
            if (user is null) return Unauthorized();

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Login) };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return Redirect(returnUrl ?? "/");
        }
        public void OnGet()
        {
            
        }
    }
}
