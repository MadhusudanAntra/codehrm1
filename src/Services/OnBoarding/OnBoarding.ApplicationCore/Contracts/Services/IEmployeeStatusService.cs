using System;
using OnBoarding.ApplicationCore.Models;

namespace OnBoarding.ApplicationCore.Contracts.Services
{
	public interface IEmployeeStatusService
	{
        Task<IEnumerable<EmployeeStatusInfoModel>> GetAll();
        Task<EmployeeStatusInfoModel> GetById(int id);
        Task<EmployeeStatusInfoModel> Add(EmployeeStatusCreateModel employeeStatus);
        Task<EmployeeStatusInfoModel> Update(EmployeeStatusInfoModel employeeStatus);
        Task<bool> Delete(EmployeeStatusInfoModel employeeStatus);
    }
}