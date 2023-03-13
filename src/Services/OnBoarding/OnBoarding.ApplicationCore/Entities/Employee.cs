using System;
using System.ComponentModel.DataAnnotations;

namespace OnBoarding.ApplicationCore.Entities
{
	public class Employee
	{
		[Key]
		public int EmployeeId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public string SSN { get; set; }
		public DateTime HireDate { get; set; }
		public DateTime EndDate { get; set; }
		public EmployeeCategory EmployeeCategoryCode { get; set; }
		public EmployeeStatus EmployeeStatusCode { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public EmployeeRole EmployeeRoleId { get; set; }
	} 
}