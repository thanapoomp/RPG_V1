using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPG_project.DTOs.Charactor;
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
    }
}