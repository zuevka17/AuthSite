using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using ZuevKiselev_15.Models;
using ZuevKiselev_15.wwwroot;

namespace ZuevKiselev_15.Pages.AirplanesCRUD
{
    [Authorize]
    public class AirplanesModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
