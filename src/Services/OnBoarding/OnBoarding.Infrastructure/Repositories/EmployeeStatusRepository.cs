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

        public async Task<EmployeeStatus> GetById(int id)
        {
            var status = await _dbContext.EmployeeStatuses.Where(s => s.StatusID == id).FirstOrDefaultAsync();
            return status;
        }
    }
}

