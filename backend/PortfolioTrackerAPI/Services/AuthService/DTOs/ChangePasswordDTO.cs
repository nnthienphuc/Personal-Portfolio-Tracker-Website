namespace PortfolioTrackerAPI.Services.AuthService.DTOs
{
    public class ChangePasswordDTO
    {
        public required string OldPassword { get; set; }
        public required string NewPassword { get; set; }
        public required string ConfirmNewPassword { get; set; }
    }
}
