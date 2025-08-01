using EmployeeServices.UnitofWork.Repository;

namespace EmployeeServices.UnitofWork
{
    public interface IEmployeeUnitofWork
    {
        Task SaveDatas();
        IEmployeeRepository employeeRepository { get; }
    }
}
