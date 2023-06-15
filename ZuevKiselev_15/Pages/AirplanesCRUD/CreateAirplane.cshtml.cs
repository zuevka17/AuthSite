using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZuevKiselev_15.Models;


namespace ZuevKiselev_15.Pages.AirplanesCRUD
{
    [IgnoreAntiforgeryToken]
    public class CreateAirplaneModel : PageModel
    {
        public MydbContext context;
        [BindProperty]
        public Airplane airplane { get; set; } = new();
        public CreateAirplaneModel()
        {
            context = new MydbContext();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            context.Airplanes.Add(airplane);
            await context.SaveChangesAsync();
            return RedirectToPage("/AirplanesCRUD/Airplanes");
        }
    }
}
