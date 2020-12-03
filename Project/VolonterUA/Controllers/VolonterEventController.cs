using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VolonterUA.Models.Database;
using VolonterUA.Models.Localizations.Home;
using VolonterUA.Models.ViewModels.Home;
using VolonterUA.Models.ViewValidationModels.Home;

namespace VolonterUA.Controllers
{
    public class VolonterEventController : Controller
    {
        public ActionResult UpdateSubscribes(int id)
        {
            using (var context = new VolonterUAContext())
            {
                var userInfo = context.UserLoginDatas.First(x => x.Login == User.Identity.Name).UserInfo;
                var volonter = userInfo.Volonter;
                switch (Request.HttpMethod)
                {
                    case "DELETE":
                        {
                            var ev = volonter.UpcomingVolonterEvents.First(x => x.VolonterEventId == id);
                            volonter.UpcomingVolonterEvents.Remove(ev);
                            break;
                        }
                    case "POST":
                        {
                            var ev = context.UpcomingVolonterEvents.First(x => x.VolonterEventId == id);
                            volonter.UpcomingVolonterEvents.Add(ev);
                            break;
                        }
                }
                context.SaveChanges();
            }
            return Json("OK");
        }

        public ActionResult Search()
        {
            using (var context = new VolonterUAContext())
            {
                UserInfo info = null;
                if (User.Identity.IsAuthenticated)
                {
                    info = context.UserLoginDatas.First(x => x.Login == User.Identity.Name).UserInfo;
                }
                var view = View("~/Views/Home/VolonterHomePage.cshtml", new VolonterHomePageViewModel(
                            new VolonterHomePageLocalizationUkraine(),
                            context.UpcomingVolonterEvents.ToList(),
                            context.InProgressVolonterEvents.ToList(),
                            info
                        )
                );
                view.ExecuteResult(ControllerContext);
                return View("~/Views/Empty.cshtml");
            }
        }
        public ActionResult Organize()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("~/Views/Home/OrganizeEvent.cshtml", new RegisterEventPageViewModel(new RegisterEventPageLocalizationUkraine()));
            }
            else
            {
                return Redirect("/Home/Index");
            }
        }
        [HttpPost]
        public ActionResult Organize([Microsoft.AspNetCore.Mvc.FromForm] RegisterEventPageViewModel model)
        {
            using (var context = new VolonterUAContext())
            {
                var organizator = context.UserLoginDatas.First(x => x.Login == User.Identity.Name).UserInfo.Organizator;
                var volonterEvent = model.ValidationModel.VolonterEvent;
                volonterEvent.VolonterOrganization = organizator.VolonterOrganization;
                context.PostEvent(volonterEvent);
                context.SaveChanges();
                return Redirect("/volonterevent/search");
            }
        }
        public ActionResult Index()
        {
            return Search();
        }
    }
}