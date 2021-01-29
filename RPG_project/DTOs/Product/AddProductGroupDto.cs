using System.ComponentModel.DataAnnotations;

namespace RPG_project.DTOs.Product
{
    public class AddProductGroupDto
    {
        [Required]
        public string Name { get; set; }
    }
}