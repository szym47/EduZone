namespace User.Domain.Models.Requests
{
    public class UpdateUserRequest
    {
        public string Email { get; set; } = default!;
        public string FullName { get; set; } = default!;
    }
}