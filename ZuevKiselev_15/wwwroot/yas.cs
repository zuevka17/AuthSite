using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZuevKiselev_15.Models;

namespace ZuevKiselev_15.wwwroot
{
    public class yas : PageModel
    {
        public IActionResult OnGet()
        {
            var form = HttpContext.Request.Form;

            int id = Convert.ToInt32(form["Delete"]);

            MydbContext mydbContext = new MydbContext();

            Airplane? airplane = mydbContext.Airplanes.FirstOrDefault(p => p.Id == id);
            if (airplane == null)
                return Redirect("/Airplanes");
            mydbContext.Airplanes.Remove(airplane);
            mydbContext.SaveChanges();
            return Redirect("/Airplanes");
        }
    }
}
