using EmployeeServices.Data;
using EmployeeServices.UnitofWork.Repository;

namespace EmployeeServices.UnitofWork
{
    public class EmployeeUnitofWork : IEmployeeUnitofWork
    {
        private readonly AppDbContext _context;
        public IEmployeeRepository employeeRepository { get; }
        public EmployeeUnitofWork(AppDbContext context)
        {
            _context = context;
            employeeRepository = new EmployeeRepository(_context);
        }

        public async Task SaveDatas()
        {
            await _context.SaveChangesAsync();
        }
    }
}
