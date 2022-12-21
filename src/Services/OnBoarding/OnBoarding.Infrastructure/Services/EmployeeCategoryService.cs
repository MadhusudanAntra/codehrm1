using System;
using OnBoarding.ApplicationCore.Contracts.Repositories;
using OnBoarding.ApplicationCore.Contracts.Services;
using OnBoarding.ApplicationCore.Entities;
using OnBoarding.ApplicationCore.Models;

namespace OnBoarding.Infrastructure.Services
{
	public class EmployeeCategoryService : IEmployeeCategoryService
    {
        private readonly IEmployeeCategoryRepository _employeeCategoryRepository;
		public EmployeeCategoryService(IEmployeeCategoryRepository employeeCategoryRepository)
		{
            _employeeCategoryRepository = employeeCategoryRepository;
		}

        public async Task<EmployeeCategoryInfoModel> Add(EmployeeCategoryCreateModel employeeCategory)
        {
            var newEmployeeCategory = new EmployeeCategory
            {
                CategoryID = 0,
                Name = employeeCategory.Name,
                Description = employeeCategory.Description
            };

            var Added = await _employeeCategoryRepository.Add(newEmployeeCategory);

            var result = new EmployeeCategoryInfoModel
            {
                CategoryID = Added.CategoryID,
                Name = Added.Name,
                Description = Added.Description
            };

            return result;
        }

        public async Task<bool> Delete(EmployeeCategoryInfoModel employeeCategory)
        {
            var Deleted = new EmployeeCategory
            {
                CategoryID = employeeCategory.CategoryID,
                Name = employeeCategory.Name,
                Description = employeeCategory.Description
            };

            var result = await _employeeCategoryRepository.Delete(Deleted);
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            };
        }

        public async Task<IEnumerable<EmployeeCategoryInfoModel>> GetAll()
        {
            var EmployeeCategories = await _employeeCategoryRepository.GetAll();

            IEnumerable<EmployeeCategoryInfoModel> result = new List<EmployeeCategoryInfoModel>();

            foreach (EmployeeCategory category in EmployeeCategories)
            {
                result.Append(new EmployeeCategoryInfoModel
                {
                    CategoryID = category.CategoryID,
                    Name = category.Name,
                    Description = category.Description
                });
            }

            return result;
        }

        public async Task<EmployeeCategoryInfoModel> GetById(int id)
        {
            var employeeCategory = await _employeeCategoryRepository.GetById(id);

            var result = new EmployeeCategoryInfoModel
            {
                CategoryID = employeeCategory.CategoryID,
                Name = employeeCategory.Name,
                Description = employeeCategory.Description
            };

            return result;
        }

        public async Task<EmployeeCategoryInfoModel> Update(EmployeeCategoryInfoModel employeeCategory)
        {
            var CategoryToUpdate = new EmployeeCategory
            {
                CategoryID = employeeCategory.CategoryID,
                Name = employeeCategory.Name,
                Description = employeeCategory.Description
            };

            var UpdatedCategory = await _employeeCategoryRepository.Update(CategoryToUpdate);

            var result = new EmployeeCategoryInfoModel
            {
                CategoryID = UpdatedCategory.CategoryID,
                Name = UpdatedCategory.Name,
                Description = UpdatedCategory.Description
            };

            return result;
        }
    }
}

