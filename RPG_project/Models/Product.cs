using System.ComponentModel.DataAnnotations.Schema;

namespace RPG_project.Models
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }
        public int ProductGroupId { get; set; }
        public ProductGroup ProductGroup { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int StockCount { get; set; }
    }
}