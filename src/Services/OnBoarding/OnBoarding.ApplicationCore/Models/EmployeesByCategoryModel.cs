using System;
namespace OnBoarding.ApplicationCore.Models
{
	public class EmployeesByCategoryModel
	{
        public int CategoryID { get; set; }
        public ICollection<EmployeeInfoModel> Employees { get; set; }
    }
}

