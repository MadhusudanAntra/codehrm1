using System;
using OnBoarding.ApplicationCore.Entities;

namespace OnBoarding.ApplicationCore.Contracts.Repositories
{
	public interface IEmployeeCategoryRepository : IRepository<EmployeeCategory>
	{
        Task<EmployeeCategory> GetById(int id);
    }
}

