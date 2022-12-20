using System;
using OnBoarding.ApplicationCore.Contracts.Services;
using OnBoarding.ApplicationCore.Entities;

namespace OnBoarding.Infrastructure.Services
{
	public class EmployeeStatusService : IEmployeeStatusService
	{
		public EmployeeStatusService()
		{
		}

        public async Task<EmployeeStatus> Add(EmployeeStatus employeeCategory)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(EmployeeStatus employeeCategory)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EmployeeStatus>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeStatus> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeStatus> Update(EmployeeStatus employeeCategory)
        {
            throw new NotImplementedException();
        }
    }
}

