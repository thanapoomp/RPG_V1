using System.Collections.Generic;
using System.Threading.Tasks;
using RPG_project.DTOs.Skill;
using RPG_project.Models;

namespace RPG_project.Services.Charactor
{
    public interface ISkillService
    {
         Task<ServiceResponse<List<GetSkillDto>>> GetAllSkills();
         Task<ServiceResponse<GetSkillDto>> GetSkillById(int id);
         Task<ServiceResponse<GetSkillDto>> AddSkill(AddSkillDto input);
    }
}