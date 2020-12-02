using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VolonterUA.Models.Database;
using VolonterUA.Models.Localizations.Personal.Volonter;
using VolonterUA.Models.Localizations.Personal.VolonterOrganization;
using VolonterUA.Models.ViewModels.Personal;

namespace VolonterUA.Controllers
{
    public class VolonterOrganizationController : Controller
    {
        public bool hasOrganization(VolonterUAContext context)
        {
            var userInfo = context.UserLoginDatas.First(x => x.Login == User.Identity.Name).UserInfo;
            return userInfo.Organizator != null;
        }

        public RedirectResult redirectHasOrganization => Redirect("/volonterevent/organize");
        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                using (var context = new VolonterUAContext())
                {
                    if (hasOrganization(context))
                    {
                        return redirectHasOrganization;
                    }
                    else
                    {
                        return View("~/Views/Personal/RegisterVolonterOrganization.cshtml", new RegisterVolonterOrganizationPageViewModel(new RegisterVolonterOrganizationPageLocalizationUkraine()));
                    }
                }
            }
            else
            {
                return View("~/Views/Personal/RegisterVolonter.cshtml", new RegisterVolonterPageViewModel(new RegisterVolonterPageLocalizationUkraine()));
            }
        }

        [HttpPost]
        public ActionResult Register([Microsoft.AspNetCore.Mvc.FromForm] RegisterVolonterOrganizationPageViewModel model)
        {
            if (model.ValidationModel.UserLoginData != null)
            {
                using (var context = new VolonterUAContext())
                {
                    var redirect = context.RegisterUser(model.ValidationModel.UserLoginData, Request, HttpContext);
                    if (redirect == "")
                    {
                        return Json(new { status = "Error" });
                    }
                }
                return View("~/Views/Personal/RegisterVolonterOrganization.cshtml", new RegisterVolonterOrganizationPageViewModel(new RegisterVolonterOrganizationPageLocalizationUkraine()));
            }
            else
            {
                using (var context = new VolonterUAContext())
                {
                    var userInfo = context.UserLoginDatas.First(x => x.Login == User.Identity.Name).UserInfo;
                    userInfo.Organizator = new Organizator
                    {
                        VolonterOrganization = model.ValidationModel.VolonterOrganization
                    };
                    context.SaveChanges();
                }
                return redirectHasOrganization;
            }
        }
    }
}