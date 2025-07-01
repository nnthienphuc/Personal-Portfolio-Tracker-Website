using Microsoft.AspNetCore.Mvc;
using PortfolioTrackerAPI.Common;

namespace PortfolioTrackerAPI.Controllers
{
    public class AuthController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
