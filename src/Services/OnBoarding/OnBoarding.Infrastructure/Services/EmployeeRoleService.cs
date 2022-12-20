using System;
using OnBoarding.ApplicationCore.Contracts.Services;
using OnBoarding.ApplicationCore.Entities;

namespace OnBoarding.Infrastructure.Services
{
	public class EmployeeRoleService : IEmployeeRoleService
	{
		public EmployeeRoleService()
		{
		}

        public async Task<EmployeeRole> Add(EmployeeRole employeeRole)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(EmployeeRole employeeRole)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EmployeeRole>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeRole> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeRole> Update(EmployeeRole employeeRole)
        {
            throw new NotImplementedException();
        }
    }
}

