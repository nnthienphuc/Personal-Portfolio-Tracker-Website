using System.ComponentModel.DataAnnotations;

namespace PortfolioTrackerAPI.Services.AuthService.DTOs
{
    public class RegisterDTO
    {
        [StringLength(50)]
        public required string Email { get; set; }

        [StringLength(100)]
        public required string FullName { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
    }
}
