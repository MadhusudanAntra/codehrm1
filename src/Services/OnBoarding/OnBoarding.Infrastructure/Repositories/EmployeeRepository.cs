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

        public Task<Employee> Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> GetById(int id)
        {
            var employee = await _dbContext.Employees.Where(e => e.EmployeeId == id).FirstOrDefaultAsync();
            return employee;
        }

        public Task<Employee> Update(Employee employee)
        {
            throw new NotImplementedException();
        }

        Task<Employee> IRepository<Employee>.Delete(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}

