using System.ComponentModel.DataAnnotations;

namespace EmployeeServices.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string? EmpName { get; set; }
    }
}
