using System;
using Microsoft.EntityFrameworkCore;
using OnBoarding.ApplicationCore.Contracts.Repositories;
using OnBoarding.ApplicationCore.Entities;
using OnBoarding.Infrastructure.Data;

namespace OnBoarding.Infrastructure.Repositories
{
	public class EmployeeStatusRepository : Repository<EmployeeStatus>, IEmployeeStatusRepository
	{
		public EmployeeStatusRepository(HRMDbContext dbContext) : base(dbContext)
		{
		}

        public async Task<EmployeeStatus> Add(EmployeeStatus employeeStatus)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EmployeeStatus>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeStatus> GetById(int id)
        {
            var status = await _dbContext.EmployeeStatuses.Where(s => s.StatusID == id).FirstOrDefaultAsync();
            return status;
        }

        public async Task<EmployeeStatus> Update(EmployeeStatus employeeStatus)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(EmployeeStatus employeeStatus)
        {
            throw new NotImplementedException();
        }
    }
}

