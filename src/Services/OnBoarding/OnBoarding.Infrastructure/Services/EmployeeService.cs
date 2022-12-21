using System;
using System.Net;
using System.Runtime.Intrinsics.X86;
using OnBoarding.ApplicationCore.Contracts.Repositories;
using OnBoarding.ApplicationCore.Contracts.Services;
using OnBoarding.ApplicationCore.Entities;
using OnBoarding.ApplicationCore.Models;
using OnBoarding.Infrastructure.Repositories;

namespace OnBoarding.Infrastructure.Services
{
	public class EmployeeService : IEmployeeService
	{
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
		{
            _employeeRepository = employeeRepository;
		}

        public async Task<EmployeeInfoModel> Add(EmployeeCreateModel employee)
        {
            var newEmployee = new Employee
            {
                EmployeeId = 0,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName,
                SSN = employee.SSN,
                HireDate = employee.HireDate,
                EndDate = employee.EndDate,
                EmployeeCategoryCode = employee.EmployeeCategoryCode,
                EmployeeStatusCode = employee.EmployeeStatusCode,
                Address = employee.Address,
                Email = employee.Email,
                EmployeeRoleId = employee.EmployeeRoleId
            };

            var Added = await _employeeRepository.Add(newEmployee);

            var result = new EmployeeInfoModel
            {
                EmployeeId = Added.EmployeeId,
                FirstName = Added.FirstName,
                LastName = Added.LastName,
                MiddleName = Added.MiddleName,
                SSN = Added.SSN,
                HireDate = Added.HireDate,
                EndDate = Added.EndDate,
                EmployeeCategoryCode = Added.EmployeeCategoryCode,
                EmployeeStatusCode = Added.EmployeeStatusCode,
                Address = Added.Address,
                Email = Added.Email,
                EmployeeRoleId = Added.EmployeeRoleId
            };

            return result;
        }

        public async Task<bool> Delete(EmployeeInfoModel employee)
        {
            var Deleted = new Employee
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName,
                SSN = employee.SSN,
                HireDate = employee.HireDate,
                EndDate = employee.EndDate,
                EmployeeCategoryCode = employee.EmployeeCategoryCode,
                EmployeeStatusCode = employee.EmployeeStatusCode,
                Address = employee.Address,
                Email = employee.Email,
                EmployeeRoleId = employee.EmployeeRoleId
            };

            var result = await _employeeRepository.Delete(Deleted);
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            };
        }

        public async Task<IEnumerable<EmployeeInfoModel>> GetAll()
        {
            var Employees = await _employeeRepository.GetAll();

            IEnumerable<EmployeeInfoModel> result = new List<EmployeeInfoModel>();

            foreach (Employee employee in Employees)
            {
                result.Append(new EmployeeInfoModel
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    MiddleName = employee.MiddleName,
                    SSN = employee.SSN,
                    HireDate = employee.HireDate,
                    EndDate = employee.EndDate,
                    EmployeeCategoryCode = employee.EmployeeCategoryCode,
                    EmployeeStatusCode = employee.EmployeeStatusCode,
                    Address = employee.Address,
                    Email = employee.Email,
                    EmployeeRoleId = employee.EmployeeRoleId
                });
            }

            return result;
        }

        public async Task<EmployeeInfoModel> GetById(int id)
        {
            var employee = await _employeeRepository.GetById(id);

            var result = new EmployeeInfoModel
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName,
                SSN = employee.SSN,
                HireDate = employee.HireDate,
                EndDate = employee.EndDate,
                EmployeeCategoryCode = employee.EmployeeCategoryCode,
                EmployeeStatusCode = employee.EmployeeStatusCode,
                Address = employee.Address,
                Email = employee.Email,
                EmployeeRoleId = employee.EmployeeRoleId
            };

            return result;
        }

        public async Task<EmployeeInfoModel> Update(EmployeeInfoModel employee)
        {
            var EmployeeToUpdate = new Employee
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName,
                SSN = employee.SSN,
                HireDate = employee.HireDate,
                EndDate = employee.EndDate,
                EmployeeCategoryCode = employee.EmployeeCategoryCode,
                EmployeeStatusCode = employee.EmployeeStatusCode,
                Address = employee.Address,
                Email = employee.Email,
                EmployeeRoleId = employee.EmployeeRoleId
            };

            var Updated = await _employeeRepository.Update(EmployeeToUpdate);

            var result = new EmployeeInfoModel
            {
                EmployeeId = Updated.EmployeeId,
                FirstName = Updated.FirstName,
                LastName = Updated.LastName,
                MiddleName = Updated.MiddleName,
                SSN = Updated.SSN,
                HireDate = Updated.HireDate,
                EndDate = Updated.EndDate,
                EmployeeCategoryCode = Updated.EmployeeCategoryCode,
                EmployeeStatusCode = Updated.EmployeeStatusCode,
                Address = Updated.Address,
                Email = Updated.Email,
                EmployeeRoleId = Updated.EmployeeRoleId
            };

            return result;
        }
    }
}

