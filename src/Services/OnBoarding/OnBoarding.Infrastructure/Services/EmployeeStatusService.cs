using System;
using OnBoarding.ApplicationCore.Contracts.Repositories;
using OnBoarding.ApplicationCore.Contracts.Services;
using OnBoarding.ApplicationCore.Entities;
using OnBoarding.ApplicationCore.Models;
using OnBoarding.Infrastructure.Repositories;

namespace OnBoarding.Infrastructure.Services
{
	public class EmployeeStatusService : IEmployeeStatusService
	{
        private readonly IEmployeeStatusRepository _employeeStatusRepository;
        public EmployeeStatusService(IEmployeeStatusRepository employeeStatusRepository)
		{
            _employeeStatusRepository = employeeStatusRepository;
		}

        public async Task<EmployeeStatusInfoModel> Add(EmployeeStatusCreateModel employeeStatus)
        {
            var newEmployeeStatus = new EmployeeStatus
            {
                StatusID = 0,
                Name = employeeStatus.Name,
                Description = employeeStatus.Description
            };

            var Added = await _employeeStatusRepository.Add(newEmployeeStatus);

            var result = new EmployeeStatusInfoModel
            {
                StatusID = Added.StatusID,
                Name = Added.Name,
                Description = Added.Description
            };

            return result;
        }

        public async Task<bool> Delete(EmployeeStatusInfoModel employeeStatus)
        {
            var Deleted = new EmployeeStatus
            {
                StatusID = employeeStatus.StatusID,
                Name = employeeStatus.Name,
                Description = employeeStatus.Description
            };

            var result = await _employeeStatusRepository.Delete(Deleted);
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            };
        }

        public async Task<IEnumerable<EmployeeStatusInfoModel>> GetAll()
        {
            var EmployeeStatuses = await _employeeStatusRepository.GetAll();

            IEnumerable<EmployeeStatusInfoModel> result = new List<EmployeeStatusInfoModel>();

            foreach (EmployeeStatus status in EmployeeStatuses)
            {
                result.Append(new EmployeeStatusInfoModel
                {
                    StatusID = status.StatusID,
                    Name = status.Name,
                    Description = status.Description
                });
            }

            return result;
        }

        public async Task<EmployeeStatusInfoModel> GetById(int id)
        {
            var employeeStatus = await _employeeStatusRepository.GetById(id);

            var result = new EmployeeStatusInfoModel
            {
                StatusID = employeeStatus.StatusID,
                Name = employeeStatus.Name,
                Description = employeeStatus.Description
            };

            return result;
        }

        public async Task<EmployeeStatusInfoModel> Update(EmployeeStatusInfoModel employeeStatus)
        {
            var StatusToUpdate = new EmployeeStatus
            {
                StatusID = employeeStatus.StatusID,
                Name = employeeStatus.Name,
                Description = employeeStatus.Description
            };

            var UpdatedStatus = await _employeeStatusRepository.Update(StatusToUpdate);

            var result = new EmployeeStatusInfoModel
            {
                StatusID = UpdatedStatus.StatusID,
                Name = UpdatedStatus.Name,
                Description = UpdatedStatus.Description
            };

            return result;
        }
    }
}

