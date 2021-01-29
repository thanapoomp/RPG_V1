using System.ComponentModel.DataAnnotations.Schema;

namespace RPG_project.Models
{
    [Table("CharactorSkill")]
    public class CharactorSkill
    {
        public Charactor Charactor { get; set; }
        public Skill Skill { get; set; }
        public int CharactorId { get; set; }
        public int SkillId { get; set; }
    }
}