namespace Technical.UI.Utility
{
    public class SD
    {
        public static string LocationAPIBase { get; set; }
        public static string BpkpAPIBase { get; set; }
        public static string AuthAPIBase { get; set; }

        public const string RoleAdmin = "Administrator";
        public const string RoleEmployee = "Employee";


        public const string TokenCookie = "JWTToken";
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
