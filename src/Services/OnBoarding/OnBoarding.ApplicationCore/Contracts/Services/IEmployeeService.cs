using System;
using OnBoarding.ApplicationCore.Entities;

namespace OnBoarding.ApplicationCore.Contracts.Services
{
	public interface IEmployeeService
	{
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task<Employee> Add(Employee employeeCategory);
        Task<Employee> Update(Employee employeeCategory);
        Task<int> Delete(Employee employeeCategory);
    }
}