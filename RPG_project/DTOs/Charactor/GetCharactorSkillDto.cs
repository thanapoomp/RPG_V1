using RPG_project.DTOs.Skill;

namespace RPG_project.DTOs.Charactor
{
    public class GetCharactorSkillDto
    {
        public GetCharactorDto Charactor { get; set; }
        public GetSkillDto Skill { get; set; }
    }
}