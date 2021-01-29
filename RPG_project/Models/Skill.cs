using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPG_project.Models
{
    [Table("Skill")]
    public class Skill
    {
         [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Damage { get; set; }
        public List<CharactorSkill> CharactorSkills { get; set; }
    }
}