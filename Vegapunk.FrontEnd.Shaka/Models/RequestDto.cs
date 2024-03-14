using static Vegapunk.FrontEnd.Shaka.Utility.StaticData;

namespace Vegapunk.FrontEnd.Shaka.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
