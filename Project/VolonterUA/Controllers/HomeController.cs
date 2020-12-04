using System.Web.Mvc;
using VolonterUA.Models.Localizations.Home;
using VolonterUA.Models.ViewModels.Home;


namespace VolonterUA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new IndexPageViewModel(new IndexPageLocalizationUkraine()));
        }
    }
}
