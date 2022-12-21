using System;

namespace OnBoarding.ApplicationCore.Models
{
	public class EmployeeInfoModel
	{
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string SSN { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime EndDate { get; set; }
        public EmployeeCategoryInfoModel EmployeeCategoryCode { get; set; }
        public EmployeeStatusInfoModel EmployeeStatusCode { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public EmployeeRoleInfoModel EmployeeRoleId { get; set; }
    }
}

