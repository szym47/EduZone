namespace User.Domain.Models.Requests
{
    public class ResetPasswordRequest
    {
        public string Email { get; set; } = default!;
        public string NewPassword { get; set; } = default!;
    }
}