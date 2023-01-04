using System;
using OnBoarding.ApplicationCore.Entities;

namespace OnBoarding.ApplicationCore.Contracts.Repositories
{
	public interface IEmployeeStatusRepository : IRepository<EmployeeStatus>
	{
		Task<EmployeeStatus> GetById(int id);
	}
}

