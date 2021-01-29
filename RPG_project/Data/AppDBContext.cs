using Microsoft.EntityFrameworkCore;
using RPG_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_project.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        public DbSet<Charactor> Charactors { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<CharactorSkill> CharactorSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharactorSkill>().HasKey(x => new {x.CharactorId,x.SkillId});
        }
    }
}