using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZuevKiselev_15.Models;
namespace ZuevKiselev_15.Pages.AirplanesCRUD
{
    [IgnoreAntiforgeryToken]
    public class EditAirplaneModel : PageModel
    {
        MydbContext context;
        [BindProperty]
        public Airplane? airplane { get; set; }

        public EditAirplaneModel()
        {

            context = new MydbContext();
        }
        public async Task<IActionResult> OnGetAsync()
        {
            int id = Convert.ToInt32(HttpContext.Request.Query["Edit"]);

            airplane = await context.Airplanes.FindAsync(id);

            if (airplane == null) return NotFound();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            context.Airplanes.Update(airplane!);
            await context.SaveChangesAsync();
            return RedirectToPage("/AirplanesCRUD/Airplanes");
        }
    }
}
