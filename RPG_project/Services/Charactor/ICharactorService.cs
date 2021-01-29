using System.Collections.Generic;
using System.Threading.Tasks;
using RPG_project.Models;
using RPG_project.DTOs.Charactor;
using RPG_project.DTOs.Weapon;
using RPG_project.DTOs.Fight;

namespace RPG_project.Services.Charactor
{
    public interface ICharactorService
    {
        Task<ServiceResponse<GetCharactorDto>> AddCharactor(AddCharactorDto input);
        Task<ServiceResponse<List<GetCharactorDto>>> GetAllCharactors();
        Task<ServiceResponse<GetCharactorDto>> GetAllCharactorById(int id);
        Task<ServiceResponse<GetCharactorDto>> AddWeapon(AddWeaponDto newWeapon);
        Task<ServiceResponse<GetCharactorDto>> RemoveCharactorWeapon(int charactorId);
        Task<ServiceResponse<GetCharactorDto>> AddCharactorSkill(AddCharactorSkillDto input);
        Task<ServiceResponse<GetCharactorDto>> RemoveCharactorSkill(int charactorId);
        Task<ServiceResponse<AttackResultDto>> WeaponAtk(WeaponAtkDto input);
        Task<ServiceResponse<AttackResultDto>> SkillAtk(SkillAtkDto input);

    }
}