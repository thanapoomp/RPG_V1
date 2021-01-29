using System.Collections.Generic;

namespace RPG_project.DTOs.Product
{
    public class GetProductGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GetProductDto> Products { get; set; }
    }
}