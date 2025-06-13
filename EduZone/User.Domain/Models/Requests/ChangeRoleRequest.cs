namespace User.Domain.Models.Requests
{
    public class ChangeRoleRequest
    {
        public string NewRole { get; set; } = default!;
    }
}
