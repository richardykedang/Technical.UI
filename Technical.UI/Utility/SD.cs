namespace Technical.UI.Utility
{
    public class SD
    {
        public static string LocationAPIBase { get; set; }
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
