using Microsoft.AspNetCore.Mvc;

namespace PortfolioTrackerAPI.Controllers
{
    public class AssetTypesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
