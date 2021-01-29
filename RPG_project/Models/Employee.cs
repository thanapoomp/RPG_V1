using System.ComponentModel.DataAnnotations.Schema;

namespace RPG_project.Models
{
    [Table("Employee")]
    public class Employee
    {
        public int Id { get; set; }
        public string FirstNameXXX { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}