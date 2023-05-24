using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Tls;
using Microsoft.Identity.Client;

namespace ZuevKiselev_15.Pages
{

    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Auth");
        }
    }
}
