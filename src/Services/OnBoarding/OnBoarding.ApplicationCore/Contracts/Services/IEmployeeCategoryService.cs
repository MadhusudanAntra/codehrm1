using System;
using OnBoarding.ApplicationCore.Models;

namespace OnBoarding.ApplicationCore.Contracts.Services
{
	public interface IEmployeeCategoryService
	{
        Task<IEnumerable<EmployeeCategoryInfoModel>> GetAll();
        Task<EmployeeCategoryInfoModel> GetById(int id);
        Task<EmployeeCategoryInfoModel> Add(EmployeeCategoryCreateModel employeeCategory);
        Task<EmployeeCategoryInfoModel> Update(EmployeeCategoryInfoModel employeeCategory);
        Task<bool> Delete(int id);
    }
}