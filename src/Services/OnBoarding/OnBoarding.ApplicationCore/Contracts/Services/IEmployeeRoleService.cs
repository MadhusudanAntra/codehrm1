using System;
using OnBoarding.ApplicationCore.Entities;

namespace OnBoarding.ApplicationCore.Contracts.Services
{
	public interface IEmployeeRoleService
	{
        Task<IEnumerable<EmployeeRole>> GetAll();
        Task<EmployeeRole> GetById(int id);
        Task<EmployeeRole> Add(EmployeeRole employeeRole);
        Task<EmployeeRole> Update(EmployeeRole employeeRole);
        Task<int> Delete(EmployeeRole employeeRole);
    }
}