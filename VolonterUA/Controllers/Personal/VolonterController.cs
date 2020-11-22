using System.Web.Mvc;
using VolonterUA.Models.Localizations.Personal.Volonter;
using VolonterUA.Models.ViewModels.Personal;
using VolonterUA.Models.ViewValidationModels.Personal;

namespace VolonterUA.Controllers
{
    public class VolonterController : Controller
    {
        public ActionResult Register(RegisterVolonterPageViewModel da)
        {
            return View("~/Views/Personal/RegisterVolonter.cshtml", new RegisterVolonterPageViewModel(new RegisterVolonterPageLocalizationUkraine()));
        }

        [HttpPost]
        public ActionResult Register(FormCollection form)
        {
            if (ModelState.IsValid)
            {

                return Redirect("/Home/Index");
            }
            else
            {
                return Json(new { status = "Error", message = "Error while registering volonter" });
            }
        }
    }
}