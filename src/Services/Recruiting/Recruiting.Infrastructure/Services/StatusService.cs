using Recruiting.ApplicationCore.Contracts.Repositories;
using Recruiting.ApplicationCore.Contracts.Services;
using Recruiting.ApplicationCore.Entities;
using Recruiting.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Infrastructure.Services
{
    public class StatusService : IStatusService
    {
        IEmployeeTypeRepository employeeTypeRepository;
        public EmployeeTypeService(IEmployeeTypeRepository _employeeTypes)
        {
            employeeTypeRepository = _employeeTypes;
        }
        public async Task<int> AddEmployeeTypeAsync(EmployeeTypeRequestModel model)
        {
            var existingEmployeeType = await employeeTypeRepository.GetUserByEmail(model.Email);
            if (existingEmployeeType != null)
            {
                throw new Exception("Email is already used");
            }
            EmployeeType EmployeeType = new EmployeeType();
            if (model != null)
            {
                EmployeeType.FirstName = model.FirstName;
            }
            //returns number of rows affected, typically 1
            return await employeeTypeRepository.InsertAsync(EmployeeType);
        }

        public async Task<int> DeleteEmployeeTypeAsync(int id)
        {
            //returns number of rows affected, typically 1
            return await employeeTypeRepository.DeleteAsync(id);
        }

        public async Task<List<EmployeeType>> GetAllEmployeeTypes()
        {
            return (await employeeTypeRepository.GetAllAsync()).ToList();
        }

        public async Task<int> UpdateEmployeeTypeAsync(EmployeeTypeRequestModel model)
        {
            var existingEmployeeType = await employeeTypeRepository.GetUserByEmail(model.Email);
            if (existingEmployeeType == null)
            {
                throw new Exception("EmployeeType does not exist");
            }
            EmployeeType EmployeeType = new EmployeeType();
            if (model != null)
            {
                EmployeeType.EmployeeTypeId = model.EmployeeTypeId;
                EmployeeType.FirstName = model.FirstName;
                EmployeeType.MiddleName = model.MiddleName;
                EmployeeType.LastName = model.LastName;
                EmployeeType.Email = model.Email;
                EmployeeType.ResumeURL = model.ResumeURL;
                return await employeeTypeRepository.UpdateAsync(EmployeeType);
            }
            else
            {
                //unsuccessful update
                return -1;
            }

        }
    }
}
