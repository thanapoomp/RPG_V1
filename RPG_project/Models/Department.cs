using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPG_project.Models
{
    [Table("Department")]
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}