using System;
using System.ComponentModel.DataAnnotations;

namespace OnBoarding.ApplicationCore.Entities
{
	public class EmployeeRole
	{
		[Key]
		public int RoleID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}
}

