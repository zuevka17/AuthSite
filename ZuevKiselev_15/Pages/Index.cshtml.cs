using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZuevKiselev_15.Models;

namespace ZuevKiselev_15.Pages
{
    [Authorize]
    public class IndexModel : BasePageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Representative> Representatives { get; set; }

        public IndexModel()
        {
            MydbContext db = new MydbContext();
            Representatives = db.Representatives.ToList();
        }
        public void OnGet()
        {

        }
    }
}