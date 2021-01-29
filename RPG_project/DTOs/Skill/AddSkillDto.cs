using System.ComponentModel.DataAnnotations;

namespace RPG_project.DTOs.Skill
{
    public class AddSkillDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1,100)]
        public int Damage { get; set; }
    }
}