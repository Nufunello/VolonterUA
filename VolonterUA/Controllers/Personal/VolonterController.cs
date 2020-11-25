using System.Linq;
using System.Web.Mvc;
using VolonterUA.Models.Database;
using VolonterUA.Models.Localizations.Personal.Volonter;
using VolonterUA.Models.ViewModels.Personal;
using VolonterUA.Models.ViewValidationModels.Personal;

namespace VolonterUA.Controllers
{
    public class VolonterController : Controller
    {
        public ActionResult Register()
        {
            return View("~/Views/Personal/RegisterVolonter.cshtml", new RegisterVolonterPageViewModel(new RegisterVolonterPageLocalizationUkraine()));
        }

        [HttpPost]
        public ActionResult Register([Microsoft.AspNetCore.Mvc.FromForm] RegisterVolonterPageViewModel model)
        {
            if (ModelState.IsValid)
            {

                return Redirect("/Home/Index");
            }
            else
            {
                var errors = string.Join(",", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                return Json(new { status = "Error", message = errors });
            }
        }
    }
}