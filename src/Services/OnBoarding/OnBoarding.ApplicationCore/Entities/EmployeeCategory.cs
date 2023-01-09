using System;
using System.ComponentModel.DataAnnotations;

namespace OnBoarding.ApplicationCore.Entities
{
	public class EmployeeCategory
	{
		[Key]
		public int CategoryID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}
}

