namespace Vegapunk.Services.OrderAPI.Models.Dto
{
    public class YorkPaymentRequestDto
    {
        public string? SessionUrl { get; set; }
        public string? SessionToken { get; set; }
        public string? ApprovedUrl { get; set; }
        public string? CancelUrl { get; set; }
        public OrderHeaderDto OrderHeader { get; set; }
    }
}
