using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZuevKiselev_15.Models;

namespace ZuevKiselev_15.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<User> Users { get; set; }

        public IndexModel()
        {
            Is5110Context db = new Is5110Context();
            Users = db.Users.ToList();
        }
        public void OnGet()
        {

        }
    }
}