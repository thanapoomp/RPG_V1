using AutoMapper;
using RPG_project.DTOs.Charactor;
using RPG_project.DTOs.Skill;
using RPG_project.DTOs.Weapon;
using RPG_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_project
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Charactor,GetCharactorDto>().ReverseMap();
            CreateMap<Weapon,GetWeaponDto>().ReverseMap();
            CreateMap<Skill,GetSkillDto>().ReverseMap();
            CreateMap<Skill,AddSkillDto>().ReverseMap();
            CreateMap<CharactorSkill,AddCharactorSkillDto>().ReverseMap();
            CreateMap<CharactorSkill,GetCharactorSkillDto>().ReverseMap();
        }
    }
}