using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZuevKiselev_15.Models;

namespace ZuevKiselev_15.Pages.AirplanesCRUD
{
    public class DeleteAirplaneModel : PageModel
    {
        public IActionResult OnGet()
        {
            int id = Convert.ToInt32(HttpContext.Request.Query["Delete"]);

            MydbContext mydbContext = new MydbContext();

            Airplane? airplane = mydbContext.Airplanes.FirstOrDefault(p => p.Id == id);
            if (airplane == null)
                return Redirect("/AirplanesCRUD/Airplanes");
            mydbContext.Airplanes.Remove(airplane);
            mydbContext.SaveChanges();
            return Redirect("/AirplanesCRUD/Airplanes");
        }
    }
}
