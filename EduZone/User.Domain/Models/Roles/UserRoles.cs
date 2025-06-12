namespace User.Domain.Roles
{
    public static class UserRoles
    {
        public const string Admin = "Admin";
        public const string Client = "Client";
        public const string Employee = "Employee";

        public static readonly HashSet<string> All = new() { Admin, Client, Employee };
    }
}
