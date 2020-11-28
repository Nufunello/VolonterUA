using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VolonterUA.Models.Database;
using VolonterUA.Models.Localizations.Personal.Volonter;
using VolonterUA.Models.ViewModels.Personal;
using VolonterUA.Models.ViewValidationModels.Personal;

namespace VolonterUA.Controllers
{
    public class VolonterController : Controller
    {
        public VolonterController()
        {

        }

        public ActionResult SignOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return Redirect("/Home/Index");
        }

        public ActionResult Register()
        {
            return User.Identity.IsAuthenticated
                ? Redirect("/Home/Index")
                : (ActionResult)View("~/Views/Personal/RegisterVolonter.cshtml", new RegisterVolonterPageViewModel(new RegisterVolonterPageLocalizationUkraine()));
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Register([Microsoft.AspNetCore.Mvc.FromForm] RegisterVolonterPageViewModel model)
        {
            if (ModelState.IsValid && !User.Identity.IsAuthenticated)
            {
                using (var context = new VolonterUAContext())
                {
                    var userManager = context.UserManager;
                    var user = new IdentityUser
                    {
                        UserName = model.ValidationModel.UserLoginData.Login,
                        PasswordHash = model.ValidationModel.UserLoginData.Password
                    };
                    var result = await userManager.CreateAsync(user);
                    if (result.Succeeded)
                    {
                        var signInManager = new SignInManager<IdentityUser, string>(userManager, HttpContext.GetOwinContext().Authentication);
                        await signInManager.SignInAsync(user, false, false);
                        return Redirect("/Home/Index");
                    }
                }
                return Json(new { status = "Error" });
            }
            else
            {
                var errors = string.Join(",", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                return Json(new { status = "Error", message = errors });
            }
        }
    }
}