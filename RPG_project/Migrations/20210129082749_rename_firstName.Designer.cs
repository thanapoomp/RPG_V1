﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RPG_project.Data;

namespace RPG_project.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20210129082749_rename_firstName")]
    partial class rename_firstName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RPG_project.Models.Charactor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("HitPoint")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Charactor");
                });

            modelBuilder.Entity("RPG_project.Models.CharactorSkill", b =>
                {
                    b.Property<int>("CharactorId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("CharactorId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("CharactorSkill");
                });

            modelBuilder.Entity("RPG_project.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("RPG_project.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("FirstNameXXX")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("RPG_project.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("RPG_project.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharactorId")
                        .HasColumnType("int");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharactorId")
                        .IsUnique();

                    b.ToTable("Weapon");
                });

            modelBuilder.Entity("RPG_project.Models.CharactorSkill", b =>
                {
                    b.HasOne("RPG_project.Models.Charactor", "Charactor")
                        .WithMany("CharactorSkills")
                        .HasForeignKey("CharactorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RPG_project.Models.Skill", "Skill")
                        .WithMany("CharactorSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RPG_project.Models.Employee", b =>
                {
                    b.HasOne("RPG_project.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RPG_project.Models.Weapon", b =>
                {
                    b.HasOne("RPG_project.Models.Charactor", "Charactor")
                        .WithOne("Weapon")
                        .HasForeignKey("RPG_project.Models.Weapon", "CharactorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
