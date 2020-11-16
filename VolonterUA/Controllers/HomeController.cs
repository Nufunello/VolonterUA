using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VolonterUA.Models.Localizations.IndexPage;
using VolonterUA.Models.ViewsModels;

namespace VolonterUA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new IndexPageViewModel ( new IndexPageLocalizationUkraine() ));
        }
    }
}
