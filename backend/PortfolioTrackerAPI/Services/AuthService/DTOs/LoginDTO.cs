using System.ComponentModel.DataAnnotations;

namespace PortfolioTrackerAPI.Services.AuthService.DTOs
{
    public class LoginDTO
    {
        [StringLength(50)]
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
