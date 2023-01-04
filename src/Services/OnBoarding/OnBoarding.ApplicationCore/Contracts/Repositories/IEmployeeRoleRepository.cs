using System;
using OnBoarding.ApplicationCore.Entities;

namespace OnBoarding.ApplicationCore.Contracts.Repositories
{
	public interface IEmployeeRoleRepository : IRepository<EmployeeRole>
	{
        Task<EmployeeRole> GetById(int id);
    }
}

