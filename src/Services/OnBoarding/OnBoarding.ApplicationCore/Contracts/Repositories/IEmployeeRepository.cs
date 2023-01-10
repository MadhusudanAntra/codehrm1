using System;
using OnBoarding.ApplicationCore.Entities;

namespace OnBoarding.ApplicationCore.Contracts.Repositories
{
	public interface IEmployeeRepository : IRepository<Employee>
	{
        Task<Employee> GetById(int id);
    }
}

