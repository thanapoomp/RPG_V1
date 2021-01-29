using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RPG_project.Data;
using RPG_project.DTOs.Skill;
using RPG_project.Models;

namespace RPG_project.Services.Charactor
{
    public class SkillService : ISkillService
    {
        private readonly AppDBContext dbContext;
        private readonly IMapper mapper;
        private readonly ILogger<ISkillService> log;

        public SkillService(AppDBContext dbContext, IMapper mapper, ILogger<ISkillService> log)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.log = log;
        }
        public async Task<ServiceResponse<List<GetSkillDto>>> GetAllSkills()
        {
            var skills = await dbContext.Skills.ToListAsync();
            var dto = mapper.Map<List<GetSkillDto>>(skills);
            return ResponseResult.Success(dto);
        }

        public async Task<ServiceResponse<GetSkillDto>> GetSkillById(int id)
        {
            var skill = await dbContext.Skills.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (skill == null)
            {
                return ResponseResult.Failure<GetSkillDto>("Skill not found");
            }

            var dto = mapper.Map<GetSkillDto>(skill);

            return ResponseResult.Success(dto);
        }

        public async Task<ServiceResponse<GetSkillDto>> AddSkill(AddSkillDto input)
        {
            var skill = new Skill();
            skill.Name = input.Name;
            skill.Damage = input.Damage;

            await dbContext.Skills.AddAsync(skill);
            await dbContext.SaveChangesAsync();

            var dto = mapper.Map<GetSkillDto>(skill);

            return ResponseResult.Success(dto);
        }
    }
}