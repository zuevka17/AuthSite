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

            if (!form.ContainsKey("Name") || !form.ContainsKey("Password"))
                return BadRequest("Name и/или пароль не установлены");

            string Name = form["Name"];
            string Password =form["Password"];

            var db = new MydbContext();

            Representative? user = db.Representatives.FirstOrDefault(p => p.Name == Name && p.Password == Password);
            if (user is null) return Unauthorized();

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Name) };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return Redirect(returnUrl ?? "/");
        }
    }
}
