using System;
using OnBoarding.ApplicationCore.Entities;

namespace OnBoarding.ApplicationCore.Contracts.Repositories
{
	public interface IEmployeeCategoryRepository : IRepository<EmployeeCategory>
	{
        Task<IEnumerable<EmployeeCategory>> GetAll();
        Task<EmployeeCategory> GetById(int id);
        Task<EmployeeCategory> Add(EmployeeCategory employeeCategory);
        Task<EmployeeCategory> Update(EmployeeCategory employeeCategory);
        Task<int> Delete(EmployeeCategory employeeCategory);
    }
}

