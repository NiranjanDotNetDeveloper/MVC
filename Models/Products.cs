using System.ComponentModel.DataAnnotations;

namespace NewProjectOnMVCFullStack.Models
{
    public class Products
    {
        [Key]
        public int? CategoryId { get; set; }
        public string? ProductName { get; set; }
        public double? Price { get; set; }
        public int? QtyAvailable { get; set; }
    }
}
