namespace Vegapunk.FrontEnd.Shaka.Utility
{
    public class StaticData
    {
        public static string CouponAPIBase { get; set; }
        public static string ProductAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
