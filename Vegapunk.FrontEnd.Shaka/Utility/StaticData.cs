﻿namespace Vegapunk.FrontEnd.Shaka.Utility
{
    public class StaticData
    {
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
