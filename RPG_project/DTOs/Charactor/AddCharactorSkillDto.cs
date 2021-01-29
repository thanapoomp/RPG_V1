using System.ComponentModel.DataAnnotations;

namespace RPG_project.DTOs.Charactor
{
    public class AddCharactorSkillDto
    {
        [Required]
        public int CharactorId { get; set; }
        [Required]
        public int SkillId { get; set; }
    }
}