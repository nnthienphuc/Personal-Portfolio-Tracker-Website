using Microsoft.AspNetCore.Mvc;

namespace PortfolioTrackerAPI.Common
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
