using System.ComponentModel.DataAnnotations;

namespace RPG_project.DTOs.Charactor
{
    public class AddCharactorDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, 300)]
        public int HitPoint { get; set; }
        [Required]
        [Range(1, 50)]
        public int Strength { get; set; }
        [Required]
        [Range(1, 50)]
        public int Defense { get; set; }
        [Required]
        [Range(1, 50)]
        public int Intelligence { get; set; }
    }
}