using Recruiting.ApplicationCore.Contracts.Repositories;
using Recruiting.ApplicationCore.Contracts.Services;
using Recruiting.ApplicationCore.Entities;
using Recruiting.ApplicationCore.Exceptions;
using Recruiting.ApplicationCore.Models;
using Recruiting.Infrastructure.Helpers;
using Recruiting.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Infrastructure.Services
{
    public class EmployeeTypeService : IEmployeeTypeService
    {
        IEmployeeTypeRepository employeeTypeRepository;
        public EmployeeTypeService(IEmployeeTypeRepository _employeeTypes)
        {
            employeeTypeRepository = _employeeTypes;
        }
        public async Task<int> AddEmployeeTypeAsync(EmployeeTypeRequestModel model)
        {
            var existingEmployeeType = await employeeTypeRepository.GetEmployeeTypeByTypeName(model.TypeName);
            if (existingEmployeeType != null)
            {
                throw new Exception("Employee Type already exists");
            }
            EmployeeType EmployeeType = new EmployeeType();
            if (model != null)
            {
                EmployeeType.TypeName = model.TypeName.ToLower();
            }
            //returns number of rows affected, typically 1
            return await employeeTypeRepository.InsertAsync(EmployeeType);
        }

        public async Task<int> DeleteEmployeeTypeAsync(int id)
        {
            //returns number of rows affected, typically 1
            return await employeeTypeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeTypeResponseModel>> GetAllEmployeeTypes()
        {
            var empTypes = await employeeTypeRepository.GetAllAsync();
            var response = empTypes.Select(x => x.ToEmployeeTypeResponseModel());
            return response;
        }
        public async Task<EmployeeTypeResponseModel> GetEmployeeTypeByIdAsync(int id)
        {
            var empType = await employeeTypeRepository.GetByIdAsync(id);
            if (empType != null)
            {
                var response = empType.ToEmployeeTypeResponseModel();
                return response;
            }
            else
            {
                throw new NotFoundException("EmployeeType", id);
            }
        }

        public async Task<int> UpdateEmployeeTypeAsync(EmployeeTypeRequestModel model)
        {
            var existingEmployeeType = await employeeTypeRepository.GetEmployeeTypeByTypeName(model.TypeName);
            if (existingEmployeeType == null)
            {
                throw new Exception("EmployeeType does not exist");
            }
            EmployeeType employeeType = new EmployeeType();
            if (model != null)
            {
                employeeType.TypeName = model.TypeName.ToLower();
                return await employeeTypeRepository.UpdateAsync(employeeType);
            }
            else
            {
                //unsuccessful update
                return -1;
            }

        }
    }
}
