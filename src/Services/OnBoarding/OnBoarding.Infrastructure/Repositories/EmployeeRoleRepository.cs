using System;
using Microsoft.EntityFrameworkCore;
using OnBoarding.ApplicationCore.Contracts.Repositories;
using OnBoarding.ApplicationCore.Entities;
using OnBoarding.Infrastructure.Data;

namespace OnBoarding.Infrastructure.Repositories
{
	public class EmployeeRoleRepository : Repository<EmployeeRole>, IEmployeeRoleRepository
	{
		public EmployeeRoleRepository(HRMDbContext dbContext) : base(dbContext)
		{
		}

        public async Task<EmployeeRole> Add(EmployeeRole employeeRole)
        {
            throw new NotImplementedException();
        }
     
        public async Task<IEnumerable<EmployeeRole>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeRole> GetById(int id)
        {
            var role = await _dbContext.EmployeeRoles.Where(r => r.RoleID == id).FirstOrDefaultAsync();
            return role;
        }

        public async Task<EmployeeRole> Update(EmployeeRole employeeRole)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(EmployeeRole employeeRole)
        {
            throw new NotImplementedException();
        }
    }
}

