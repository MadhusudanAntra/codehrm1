using System;
using OnBoarding.ApplicationCore.Entities;

namespace OnBoarding.ApplicationCore.Contracts.Repositories
{
	public interface IEmployeeRepository : IRepository<Employee>
	{
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task<Employee> Add(Employee employee);
        Task<Employee> Update(Employee employee);
        Task<int> Delete(Employee employee);
    }
}

