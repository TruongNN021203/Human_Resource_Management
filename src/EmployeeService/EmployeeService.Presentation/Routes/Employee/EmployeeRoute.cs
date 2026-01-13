namespace Presentation.Routes;

public static class Router
{
    public static class EmployeeRoutes
    {
        public const string Tags = "Employees";
        public const string Employees = "api/employees";
        public const string EmployeeDetail = $"{Employees}/{{id:long}}";
    }

}
