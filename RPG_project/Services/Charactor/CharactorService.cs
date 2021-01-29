using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RPG_project.Data;
using RPG_project.DTOs.Charactor;
using RPG_project.DTOs.Fight;
using RPG_project.DTOs.Weapon;
using RPG_project.Models;

namespace RPG_project.Services.Charactor
{
    public class CharactorService : ICharactorService
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger _log;

        public CharactorService(AppDBContext dbContext, IMapper mapper, ILogger<CharactorService> log)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
            this._log = log;
        }

        public async Task<Models.ServiceResponse<GetCharactorDto>> GetAllCharactorById(int id)
        {
            var charactor = await _dbContext.Charactors
            .Include(x => x.Weapon)
            .Where(x => x.Id == id).FirstOrDefaultAsync();

            if (charactor == null)
            {
                return ResponseResult.Failure<GetCharactorDto>("Character not found.");
            }

            var dto = _mapper.Map<GetCharactorDto>(charactor);
            return ResponseResult.Success(dto);
        }

        public async Task<Models.ServiceResponse<List<GetCharactorDto>>> GetAllCharactors()
        {
            var charactors = await _dbContext.Charactors
            .Include(x => x.Weapon)
            .Include(x => x.CharactorSkills).ThenInclude(x => x.Skill)
            .AsNoTracking().ToListAsync();
            var dto = _mapper.Map<List<GetCharactorDto>>(charactors);
            return ResponseResult.Success(dto);
        }

        public async Task<ServiceResponse<GetCharactorDto>> AddWeapon(AddWeaponDto newWeapon)
        {
            //check charactor exsist
            var charactor = await _dbContext.Charactors.Where(x => x.Id == newWeapon.CharactorId).FirstOrDefaultAsync();

            if (charactor == null)
            {
                return ResponseResult.Failure<GetCharactorDto>("Charactor not found");
            }

            var weapon = new Weapon();
            weapon.Name = newWeapon.Name;
            weapon.Damage = newWeapon.Damage;
            weapon.CharactorId = newWeapon.CharactorId;

            await _dbContext.Weapons.AddAsync(weapon);
            await _dbContext.SaveChangesAsync();

            var dto = _mapper.Map<GetCharactorDto>(charactor);
            return ResponseResult.Success(dto);
        }

        public async Task<ServiceResponse<GetCharactorDto>> AddCharactorSkill(AddCharactorSkillDto input)
        {
            //check charactor exsist
            var charactor = await _dbContext.Charactors
            .Where(x => x.Id == input.CharactorId)
            .Include(x => x.CharactorSkills)
            .ThenInclude(x => x.Skill)
            .Include(x => x.Weapon)
            .Include(x => x.Weapon)
            .FirstOrDefaultAsync();

            if (charactor is null)
            {
                return ResponseResult.Failure<GetCharactorDto>("Charactor not found");
            }

            //check skill exsist
            var skill = await _dbContext.Skills.Where(x => x.Id == input.SkillId).FirstOrDefaultAsync();

            if (skill is null)
            {
                return ResponseResult.Failure<GetCharactorDto>("Skill not found");
            }

            //check charactor skill exsists
            var charactorSkill = await _dbContext.CharactorSkills.Where(x => x.CharactorId == input.CharactorId && x.SkillId == input.SkillId).FirstOrDefaultAsync();
            if (!(charactorSkill is null))
            {
                return ResponseResult.Failure<GetCharactorDto>("Charactor skill already exsist");
            }

            //add charactor skill
            var objToAdd = new CharactorSkill();
            objToAdd.SkillId = input.SkillId;
            objToAdd.CharactorId = input.CharactorId;
            await _dbContext.CharactorSkills.AddAsync(objToAdd);
            await _dbContext.SaveChangesAsync();

            //return
            var dto = _mapper.Map<GetCharactorDto>(charactor);
            return ResponseResult.Success<GetCharactorDto>(dto);
        }

        public async Task<ServiceResponse<GetCharactorDto>> AddCharactor(AddCharactorDto input)
        {
            var newCharactor = new RPG_project.Models.Charactor();
            newCharactor.Name = input.Name;
            newCharactor.Strength = input.Strength;
            newCharactor.Intelligence = input.Intelligence;
            newCharactor.Defense = input.Defense;
            newCharactor.HitPoint = input.HitPoint;

            await _dbContext.Charactors.AddAsync(newCharactor);
            await _dbContext.SaveChangesAsync();

            //return
            var dto = _mapper.Map<GetCharactorDto>(newCharactor);

            return ResponseResult.Success<GetCharactorDto>(dto);
        }

        public async Task<ServiceResponse<AttackResultDto>> WeaponAtk(WeaponAtkDto input)
        {
            try
            {
                var attacker = await GetCharactorById(input.AttackerId);

                if (attacker is null)
                {
                    var errorMessage = $"Charactor id {input.AttackerId} not found";
                    _log.LogError(errorMessage);
                    return ResponseResult.Failure<AttackResultDto>(errorMessage);
                }

                var opponent = await GetCharactorById(input.OpponentId);

                if (opponent is null)
                {
                    var errorMessage = $"Charactor id {input.OpponentId} not found";
                    _log.LogError(errorMessage);
                    return ResponseResult.Failure<AttackResultDto>(errorMessage);
                }

                int damage;
                damage = (attacker.Weapon.Damage + attacker.Strength) - opponent.Defense;

                if (damage > 0)
                {
                    opponent.HitPoint -= damage;
                }

                _dbContext.Charactors.Update(opponent);
                await _dbContext.SaveChangesAsync();

                var dto = new AttackResultDto();
                dto.AttackerId = attacker.Id;
                dto.AttackerName = attacker.Name;
                dto.AttakerHP = attacker.HitPoint;
                dto.OpponentId = opponent.Id;
                dto.OpponentName = opponent.Name;
                dto.OpponentHp = opponent.HitPoint;
                dto.Damage = damage;

                return ResponseResult.Success<AttackResultDto>(dto);

            }
            catch (System.Exception ex)
            {
                _log.LogError(ex.Message);
                return ResponseResult.Failure<AttackResultDto>(ex.Message);
            }
        }

        public async Task<ServiceResponse<AttackResultDto>> SkillAtk(SkillAtkDto input)
        {
            try
            {
                var attacker = await GetCharactorById(input.AttackerId);

                if (attacker is null)
                {
                    var errorMessage = $"Charactor id {input.AttackerId} not found";
                    _log.LogError(errorMessage);
                    return ResponseResult.Failure<AttackResultDto>(errorMessage);
                }

                var opponent = await GetCharactorById(input.OpponentId);

                if (opponent is null)
                {
                    var errorMessage = $"Charactor id {input.OpponentId} not found";
                    _log.LogError(errorMessage);
                    return ResponseResult.Failure<AttackResultDto>(errorMessage);
                }

                var charactorSkill = await _dbContext.CharactorSkills
                .Where(x => x.CharactorId == input.AttackerId && x.SkillId == input.SkillId)
                .Include(x => x.Skill)
                .FirstOrDefaultAsync();

                if (charactorSkill is null)
                {
                    var errorMessage = $"CharactorSkill not found";
                    _log.LogError(errorMessage);
                    return ResponseResult.Failure<AttackResultDto>(errorMessage);
                }

                int damage;
                damage = (charactorSkill.Skill.Damage + attacker.Intelligence) - opponent.Intelligence;

                if (damage > 0)
                {
                    opponent.HitPoint -= damage;
                }

                _dbContext.Charactors.Update(opponent);
                await _dbContext.SaveChangesAsync();

                var dto = new AttackResultDto();
                dto.AttackerId = attacker.Id;
                dto.AttackerName = attacker.Name;
                dto.AttakerHP = attacker.HitPoint;
                dto.OpponentId = opponent.Id;
                dto.OpponentName = opponent.Name;
                dto.OpponentHp = opponent.HitPoint;
                dto.Damage = damage;

                return ResponseResult.Success<AttackResultDto>(dto);

            }
            catch (System.Exception ex)
            {
                _log.LogError(ex.Message);
                return ResponseResult.Failure<AttackResultDto>(ex.Message);
            }
        }

        public async Task<ServiceResponse<GetCharactorDto>> RemoveCharactorWeapon(int charactorId)
        {
            var charactor = await GetCharactorById(charactorId);
            
            if (charactor is null)
            {
                return ResponseResult.Failure<GetCharactorDto>($"Charactor id {charactorId} not found");
            }

            var weapon = await _dbContext.Weapons.Where(x => x.CharactorId == charactorId).FirstOrDefaultAsync();
            if (weapon !is null)
            {
                _dbContext.Weapons.Remove(weapon);
                await _dbContext.SaveChangesAsync();
            }

            var dto = _mapper.Map<GetCharactorDto>(charactor);
            return ResponseResult.Success<GetCharactorDto>(dto);
        }

        public async Task<ServiceResponse<GetCharactorDto>> RemoveCharactorSkill(int charactorId)
        {
            var charactor = await GetCharactorById(charactorId);

            if (charactor is null)
            {
                return ResponseResult.Failure<GetCharactorDto>($"Charactor id {charactorId} not found");
            }

            var skills = await _dbContext.CharactorSkills.Where(x => x.CharactorId == charactorId).ToListAsync();

            _dbContext.CharactorSkills.RemoveRange(skills);
            await _dbContext.SaveChangesAsync();

            var dto = _mapper.Map<GetCharactorDto>(charactor);
            return ResponseResult.Success<GetCharactorDto>(dto);
        }


        private async Task<RPG_project.Models.Charactor> GetCharactorById(int id)
        {
            return await _dbContext.Charactors
               .Where(x => x.Id == id)
               .Include(x => x.Weapon)
               .Include(x => x.CharactorSkills).ThenInclude(x => x.Skill)
               .FirstOrDefaultAsync();
        }


    }
}