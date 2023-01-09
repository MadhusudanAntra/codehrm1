using System;
namespace OnBoarding.ApplicationCore.Models
{
	public class EmployeesByRoleModel
	{
        public int RoleID { get; set; }
        public ICollection<EmployeeInfoModel> Employees { get; set; }
    }
}

