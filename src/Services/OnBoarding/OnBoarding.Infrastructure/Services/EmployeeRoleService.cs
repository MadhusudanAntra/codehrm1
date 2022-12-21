using System;
using OnBoarding.ApplicationCore.Contracts.Repositories;
using OnBoarding.ApplicationCore.Contracts.Services;
using OnBoarding.ApplicationCore.Entities;
using OnBoarding.ApplicationCore.Models;
using OnBoarding.Infrastructure.Repositories;

namespace OnBoarding.Infrastructure.Services
{
	public class EmployeeRoleService : IEmployeeRoleService
	{
        private readonly IEmployeeRoleRepository _employeeRoleRepository;
        public EmployeeRoleService(IEmployeeRoleRepository employeeRoleRepository)
		{
            _employeeRoleRepository = employeeRoleRepository;
		}

        public async Task<EmployeeRoleInfoModel> Add(EmployeeRoleCreateModel employeeRole)
        {
            var newEmployeeRole = new EmployeeRole
            {
                RoleID = 0,
                Name = employeeRole.Name,
                Description = employeeRole.Description
            };

            var Added = await _employeeRoleRepository.Add(newEmployeeRole);

            var result = new EmployeeRoleInfoModel
            {
                RoleID = Added.RoleID,
                Name = Added.Name,
                Description = Added.Description
            };

            return result;
        }

        public async Task<bool> Delete(EmployeeRoleInfoModel employeeRole)
        {
            var Deleted = new EmployeeRole
            {
                RoleID = employeeRole.RoleID,
                Name = employeeRole.Name,
                Description = employeeRole.Description
            };

            var result = await _employeeRoleRepository.Delete(Deleted);
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            };
        }

        public async Task<IEnumerable<EmployeeRoleInfoModel>> GetAll()
        {
            var EmployeeRoles = await _employeeRoleRepository.GetAll();

            IEnumerable<EmployeeRoleInfoModel> result = new List<EmployeeRoleInfoModel>();

            foreach (EmployeeRole role in EmployeeRoles)
            {
                result.Append(new EmployeeRoleInfoModel
                {
                    RoleID = role.RoleID,
                    Name = role.Name,
                    Description = role.Description
                });
            }

            return result;
        }

        public async Task<EmployeeRoleInfoModel> GetById(int id)
        {
            var employeeRole = await _employeeRoleRepository.GetById(id);

            var result = new EmployeeRoleInfoModel
            {
                RoleID = employeeRole.RoleID,
                Name = employeeRole.Name,
                Description = employeeRole.Description
            };

            return result;
        }

        public async Task<EmployeeRoleInfoModel> Update(EmployeeRoleInfoModel employeeRole)
        {
            var RoleToUpdate = new EmployeeRole
            {
                RoleID = employeeRole.RoleID,
                Name = employeeRole.Name,
                Description = employeeRole.Description
            };

            var UpdatedRole = await _employeeRoleRepository.Update(RoleToUpdate);

            var result = new EmployeeRoleInfoModel
            {
                RoleID = UpdatedRole.RoleID,
                Name = UpdatedRole.Name,
                Description = UpdatedRole.Description
            };

            return result;
        }
    }
}

