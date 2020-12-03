using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VolonterUA.Models.Database;
using VolonterUA.Models.Localizations.Personal.Volonter;
using VolonterUA.Models.ViewModels.Personal;

namespace VolonterUA.Controllers
{
    public class VolonterPersonalController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                using (var context = new VolonterUAContext())
                {
                    var viewModel = new VolonterPersonalPageViewModel(new VolonterPersonalPageLocalizationUkraine())
                    {
                        UserInfo = context.UserLoginDatas.First(x => x.Login == User.Identity.Name).UserInfo
                    };
                    var view = View("~/Views/Personal/VolonterPersonal.cshtml", viewModel);
                    view.ExecuteResult(ControllerContext);
                }
                return View("~/Views/Empty.cshtml");
            }
            else
            {
                return Redirect("/Home/Index");
            }
        }
    }
}
