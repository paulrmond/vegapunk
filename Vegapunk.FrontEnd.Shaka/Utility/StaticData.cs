namespace Vegapunk.FrontEnd.Shaka.Utility
{
    public class StaticData
    {
        public const string StatusPending = "Pending";
        public const string StatusApproved = "Approved";
        public const string StatusReadyForPickup = "ReadyForPickup";
        public const string StatusCompleted = "Completed";
        public const string StatusRefunded = "Refunded";
        public const string StatusCancelled = "Cancelled";
        public static string CouponAPIBase { get; set; }
        public static string ProductAPIBase { get; set; }
        public static string ShoppingCartAPIBase { get; set; }
        public static string OrderAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
