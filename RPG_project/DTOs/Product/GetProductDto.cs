namespace RPG_project.DTOs.Product
{
    public class GetProductDto
    {
        
        public int Id { get; set; }
        public int ProductGroupId { get; set; }
        public GetProductGroupDto ProductGroup { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int StockCount { get; set; }
    }
}