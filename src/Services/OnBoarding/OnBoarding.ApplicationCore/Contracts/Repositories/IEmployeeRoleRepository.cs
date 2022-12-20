using System;
using OnBoarding.ApplicationCore.Entities;

namespace OnBoarding.ApplicationCore.Contracts.Repositories
{
	public interface IEmployeeRoleRepository : IRepository<EmployeeRole>
	{
        Task<IEnumerable<EmployeeRole>> GetAll();
        Task<EmployeeRole> GetById(int id);
        Task<EmployeeRole> Add(EmployeeRole employeeRole);
        Task<EmployeeRole> Update(EmployeeRole employeeRole);
        Task<int> Delete(EmployeeRole employeeRole);
    }
}

