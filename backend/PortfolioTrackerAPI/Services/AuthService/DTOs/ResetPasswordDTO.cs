using System.ComponentModel.DataAnnotations;

namespace PortfolioTrackerAPI.Services.AuthService.DTOs
{
    public class ResetPasswordDTO
    {
        [StringLength(50)]
        public required string Email { get; set; }
    }
}
