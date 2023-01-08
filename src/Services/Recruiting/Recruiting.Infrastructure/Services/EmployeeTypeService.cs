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
    public class EmployeeTypeService : IEmployeeTypeService
    {
        IEmployeeTypeRepository employeeTypeRepository;
        public EmployeeTypeService(IEmployeeTypeRepository _employeeTypes)
        {
            employeeTypeRepository = _employeeTypes;
        }
        public async Task<int> AddEmployeeTypeAsync(EmployeeTypeRequestModel model)
        {
            var existingEmployeeType = await employeeTypeRepository.GetByConditionAsync(x => x.TypeName == model.TypeName.ToLower());
            if (existingEmployeeType != null)
            {
                throw new Exception("Employee Type already exists");
            }
            EmployeeType EmployeeType = new EmployeeType();
            if (model != null)
            {
                EmployeeType.TypeName = model.TypeName;
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
            var existingEmployeeType = await employeeTypeRepository.GetByConditionAsync(x => x.TypeName == model.TypeName.ToLower());
            if (existingEmployeeType == null)
            {
                throw new Exception("EmployeeType does not exist");
            }
            EmployeeType EmployeeType = new EmployeeType();
            if (model != null)
            {
                EmployeeType.TypeName = model.TypeName.ToLower();
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
