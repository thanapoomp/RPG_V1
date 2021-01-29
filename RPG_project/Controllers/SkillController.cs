using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPG_project.DTOs.Skill;
using RPG_project.Services.Charactor;

namespace RPG_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService skillService;

        public SkillController(ISkillService skillService)
        {
            this.skillService = skillService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSkills()
        {
            return Ok(await skillService.GetAllSkills());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkillById(int id)
        {
            return Ok(await skillService.GetSkillById(id));
        }

        [HttpPost("AddSkill")]
        public async Task<IActionResult> AddSkill(AddSkillDto input)
        {
            return Ok(await skillService.AddSkill(input));
        }


    }
}