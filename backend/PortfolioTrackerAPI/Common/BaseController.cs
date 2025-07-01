using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioTrackerAPI.Common
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public abstract class BaseController : ControllerBase
    {
    }
}
