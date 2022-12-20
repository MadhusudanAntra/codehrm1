using System;
using OnBoarding.ApplicationCore.Contracts.Services;
using OnBoarding.ApplicationCore.Entities;

namespace OnBoarding.Infrastructure.Services
{
	public class EmployeeService : IEmployeeService
	{
		public EmployeeService()
		{
		}

        public async Task<Employee> Add(Employee employeeCategory)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(Employee employeeCategory)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> Update(Employee employeeCategory)
        {
            throw new NotImplementedException();
        }
    }
}

