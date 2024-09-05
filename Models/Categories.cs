using System.ComponentModel.DataAnnotations;

namespace NewProjectOnMVCFullStack.Models
{
    public class Categories
    {
        [Key]
        public int? CategoryId { get; set; }

        public string? CategoryName { get; set; }
    }
}
