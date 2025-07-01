using Microsoft.AspNetCore.Mvc;

namespace PortfolioTrackerAPI.Controllers
{
    public class TransactionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
