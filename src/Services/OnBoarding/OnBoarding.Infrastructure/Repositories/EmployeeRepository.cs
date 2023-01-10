using System;
using Microsoft.EntityFrameworkCore;
using OnBoarding.ApplicationCore.Contracts.Repositories;
using OnBoarding.ApplicationCore.Entities;
using OnBoarding.Infrastructure.Data;

namespace OnBoarding.Infrastructure.Repositories
{
	public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
		public EmployeeRepository(HRMDbContext dbContext) : base(dbContext)
		{
		}
        public async Task<Employee> GetById(int id)
        {
            var employee = await _dbContext.Employees.Where(e => e.EmployeeId == id).FirstOrDefaultAsync();
            return employee;
        }
    }
}

