using System;
namespace OnBoarding.ApplicationCore.Models
{
	public class EmployeesByStatusModel
	{
        public int StatusID { get; set; }
        public ICollection<EmployeeInfoModel> Employees { get; set; }
    }
}