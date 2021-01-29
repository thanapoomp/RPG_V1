using System.Collections.Generic;
using RPG_project.DTOs.Skill;
using RPG_project.DTOs.Weapon;

namespace RPG_project.DTOs.Charactor
{
    public class GetCharactorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HitPoint { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public GetWeaponDto Weapon { get; set; }
        public List<GetCharactorSkillDto> CharactorSkills { get; set; }
    }
}