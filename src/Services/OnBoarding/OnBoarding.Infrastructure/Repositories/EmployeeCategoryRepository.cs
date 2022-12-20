using System;
using OnBoarding.ApplicationCore.Contracts.Repositories;
using OnBoarding.ApplicationCore.Entities;
using OnBoarding.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace OnBoarding.Infrastructure.Repositories
{
	public class EmployeeCategoryRepository : Repository<EmployeeCategory>, IEmployeeCategoryRepository
	{
		public EmployeeCategoryRepository(HRMDbContext dbContext) : base(dbContext)
		{
		}

        public async Task<EmployeeCategory> Add(EmployeeCategory entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EmployeeCategory>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeCategory> GetById(int id)
        {
            var category = await _dbContext.EmployeeCategories.Where(c => c.CategoryID == id).FirstOrDefaultAsync();
            return category;
        }

        public async Task<EmployeeCategory> Update(EmployeeCategory entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(EmployeeCategory employeeCategory)
        {
            throw new NotImplementedException();
        }
    }
}

