using System.ComponentModel.DataAnnotations;
using RPG_project.Validations;

namespace RPG_project.DTOs.Weapon
{
    public class AddWeaponDto
    {
        [Required]
        [FirstLetterUpperCaseAttribute]
        public string Name { get; set; }
        [Range(1, 100)]
        public int Damage { get; set; }
        [Required]
        public int CharactorId { get; set; }
    }
}