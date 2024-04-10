using System.ComponentModel.DataAnnotations;

namespace Vegapunk.Services.OrderAPI.Models.Dto
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
        [Range(1,100)]
        public int? Count { get; set; } = 1;
    }
}
