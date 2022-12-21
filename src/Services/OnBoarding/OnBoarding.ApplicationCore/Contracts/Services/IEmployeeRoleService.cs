using System;
using OnBoarding.ApplicationCore.Models;

namespace OnBoarding.ApplicationCore.Contracts.Services
{
	public interface IEmployeeRoleService
	{
        Task<IEnumerable<EmployeeRoleInfoModel>> GetAll();
        Task<EmployeeRoleInfoModel> GetById(int id);
        Task<EmployeeRoleInfoModel> Add(EmployeeRoleCreateModel employeeRole);
        Task<EmployeeRoleInfoModel> Update(EmployeeRoleInfoModel employeeRole);
        Task<bool> Delete(EmployeeRoleInfoModel employeeRole);
    }
}