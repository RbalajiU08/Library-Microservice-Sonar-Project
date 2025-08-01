using EmployeeServices.Model;

namespace EmployeeServices.UnitofWork.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetallEmployee();
        Task<Employee> GetEmployeebyId(int id);
        Task AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee,int id);
        Task DeleteEmployee(int id);
    }
}
