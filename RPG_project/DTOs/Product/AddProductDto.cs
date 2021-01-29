using System.ComponentModel.DataAnnotations;

namespace RPG_project.DTOs.Product
{
    public class AddProductDto
    {
        [Required]
        public int ProductGroupId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int StockCount { get; set; }
    }
}