using System;
using System.ComponentModel.DataAnnotations;

namespace OnBoarding.ApplicationCore.Entities
{
	public class EmployeeStatus
	{
		[Key]
		public int StatusID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}
}

