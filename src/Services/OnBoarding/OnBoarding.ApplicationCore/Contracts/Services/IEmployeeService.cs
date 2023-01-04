using System;
using OnBoarding.ApplicationCore.Models;

namespace OnBoarding.ApplicationCore.Contracts.Services
{
	public interface IEmployeeService
	{
        Task<IEnumerable<EmployeeInfoModel>> GetAll();
        Task<EmployeeInfoModel> GetById(int id);
        Task<EmployeeInfoModel> Add(EmployeeCreateModel employee);
        Task<EmployeeInfoModel> Update(EmployeeInfoModel employee);
        Task<bool> Delete(int id);
    }
}