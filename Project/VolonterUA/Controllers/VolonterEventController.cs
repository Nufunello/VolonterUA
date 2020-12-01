using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VolonterUA.Models.Database;
using VolonterUA.Models.Localizations.Home;
using VolonterUA.Models.ViewModels.Home;

namespace VolonterUA.Controllers
{
    public class VolonterEventController : Controller
    {
        public ActionResult Search()
        {
            using (var context = new VolonterUAContext())
            {
                string fullname = "";
                if (User.Identity.IsAuthenticated)
                {
                    var info = context.UserLoginDatas.First(x => x.Login == User.Identity.Name).UserInfo;
                    fullname = $"{info.FirstName} {info.LastName}";
                }
                var view = View("~/Views/Home/VolonterHomePage.cshtml", new VolonterHomePageViewModel(
                            new VolonterHomePageLocalizationUkraine(),
                            context.UpcomingVolonterEvents.ToList(),
                            context.InProgressVolonterEvents.ToList(),
                            fullname
                        )
                );
                view.ExecuteResult(ControllerContext);
                return View("~/Views/Empty.cshtml");
            }
        }
        public ActionResult Index()
        {
            return Search();
        }
    }
}