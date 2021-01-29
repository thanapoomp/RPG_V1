using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPG_project.Models
{
    [Table("Charactor")]
    public class Charactor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int HitPoint { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public Weapon Weapon { get; set; }
        public List<CharactorSkill> CharactorSkills { get; set; }
    }
}