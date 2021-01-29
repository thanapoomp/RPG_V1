using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPG_project.DTOs.Charactor;
using RPG_project.DTOs.Fight;
using RPG_project.DTOs.Weapon;
using RPG_project.Services.Charactor;

namespace RPG_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharactorController : ControllerBase
    {
        private readonly ICharactorService _charactorService;
        public CharactorController(ICharactorService charactorService)
        {
            _charactorService = charactorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCharactors()
        {
            return Ok(await _charactorService.GetAllCharactors());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharactorById(int id)
        {
            return Ok(await _charactorService.GetAllCharactorById(id));
        }

        [HttpPost("addWeapon")]
        public async Task<IActionResult> AddWeapon(AddWeaponDto input)
        {
            return Ok(await _charactorService.AddWeapon(input));
        }

        [HttpPost("AddCharactorSkill")]
        public async Task<IActionResult> AddCharactorSkill(AddCharactorSkillDto input)
        {
            return Ok(await _charactorService.AddCharactorSkill(input));
        }

        [HttpPost("AddCharactor")]
        public async Task<IActionResult> AddCharactor(AddCharactorDto input)
        {
            return Ok(await _charactorService.AddCharactor(input));
        }

        [HttpPut("WeaponAtk")]
        public async Task<IActionResult> WeaponAtk(WeaponAtkDto input)
        {
            return Ok(await _charactorService.WeaponAtk(input));
        }

        [HttpPut("SkillAtk")]
        public async Task<IActionResult> WeaponAtk(SkillAtkDto input)
        {
            return Ok(await _charactorService.SkillAtk(input));
        }

        [HttpDelete("RemoveCharactorSkills")]
        public async Task<IActionResult> RemoveCharactorSkills(int charactorId)
        {
            return Ok(await _charactorService.RemoveCharactorSkill(charactorId));
        }

        [HttpDelete("RemoveCharactorWeapon")]
        public async Task<IActionResult> RemoveCharactorWeapon(int charactorId)
        {
            return Ok(await _charactorService.RemoveCharactorWeapon(charactorId));
        }
    }
}