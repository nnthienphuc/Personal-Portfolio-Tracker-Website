using Microsoft.AspNetCore.Mvc;

namespace PortfolioTrackerAPI.Controllers
{
    public class AssetsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
