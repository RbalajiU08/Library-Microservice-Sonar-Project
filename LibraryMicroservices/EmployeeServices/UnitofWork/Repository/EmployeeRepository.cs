using EmployeeServices.Data;
using EmployeeServices.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeServices.UnitofWork.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
        }

        public async Task DeleteEmployee(int id)
        {
            var existingemp = await GetEmployeebyId(id);
            _context.Employees.Remove(existingemp);
        }

        public async Task<List<Employee>> GetallEmployee()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeebyId(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return employee;
        }

        public async Task UpdateEmployee(Employee employee,int id)
        {
            var existingemp = await GetEmployeebyId(id);
            existingemp.EmpName = employee.EmpName;
        }
    }
}
