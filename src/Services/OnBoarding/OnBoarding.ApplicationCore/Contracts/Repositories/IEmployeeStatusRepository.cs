using System;
using OnBoarding.ApplicationCore.Entities;

namespace OnBoarding.ApplicationCore.Contracts.Repositories
{
	public interface IEmployeeStatusRepository : IRepository<EmployeeStatus>
	{
		Task<IEnumerable<EmployeeStatus>> GetAll();
		Task<EmployeeStatus> GetById(int id);
		Task<EmployeeStatus> Add(EmployeeStatus employeeStatus);
		Task<EmployeeStatus> Update(EmployeeStatus employeeStatus);
		Task<int> Delete(EmployeeStatus employeeStatus);
	}
}

