using System;
using OnBoarding.ApplicationCore.Contracts.Services;
using OnBoarding.ApplicationCore.Entities;

namespace OnBoarding.Infrastructure.Services
{
	public class EmployeeCategoryService : IEmployeeCategoryService
    {
		public EmployeeCategoryService()
		{
		}

        public async Task<EmployeeCategory> Add(EmployeeCategory employeeCategory)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(EmployeeCategory employeeCategory)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EmployeeCategory>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeCategory> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeCategory> Update(EmployeeCategory employeeCategory)
        {
            throw new NotImplementedException();
        }
    }
}

