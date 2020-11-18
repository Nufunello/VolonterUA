using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VolonterUA.Models.Localizations.Personal.Volonter;
using VolonterUA.Models.ViewModels.Personal;
using VolonterUA.Models.ViewValidationModels.Personal;

namespace VolonterUA.Controllers
{
    public class PersonalController : Controller
    {
        public ActionResult SignUp(string role)
        {
            switch (role)
            {
                case "volonter":
                    return View("SignUpVolonter", new SignUpVolonterPageViewModel(new SignUpVolonterPageLocalizationUkraine()));

                default:
                    throw new Exception();
            }
        }
    }
}