using System;
using OnBoarding.ApplicationCore.Entities;

namespace OnBoarding.ApplicationCore.Contracts.Services
{
	public interface IEmployeeStatusService
	{
        Task<IEnumerable<EmployeeStatus>> GetAll();
        Task<EmployeeStatus> GetById(int id);
        Task<EmployeeStatus> Add(EmployeeStatus employeeCategory);
        Task<EmployeeStatus> Update(EmployeeStatus employeeCategory);
        Task<int> Delete(EmployeeStatus employeeCategory);
    }
}