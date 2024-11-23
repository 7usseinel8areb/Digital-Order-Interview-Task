namespace DigitalOrder.Core.AppMetaData
{
    public static class Router
    {
        private const string Root = "api";
        private const string Version = "v1";
        private const string BaseRoute = $"{Root}/{Version}";

        public static class ProductRoutes
        {
            private const string Prefix = $"{BaseRoute}/product";

            public const string List = $"{Prefix}/list";
            public const string GetById = $"{Prefix}/{{id}}";
            public const string Create = $"{Prefix}/create";
            public const string Edit = $"{Prefix}/edit";
            public const string Delete = $"{Prefix}/delete/{{id}}";
        }

        public static class AuthRoutes
        {
            private const string Prefix = $"{BaseRoute}/auth";

            public const string Register = $"{Prefix}/register";
            public const string SignIn = $"{Prefix}/sign-in";
        }

        public static class UserRoutes
        {
            private const string Prefix = $"{BaseRoute}/user";

            public const string GetById = $"{Prefix}/{{id}}";
            public const string Edit = $"{Prefix}/edit";
            public const string Delete = $"{Prefix}/delete/{{id}}";
            public const string ChangePassword = $"{Prefix}/change-password";
        }
    }
}
