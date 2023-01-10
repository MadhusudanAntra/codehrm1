using System;
using Microsoft.EntityFrameworkCore;
using OnBoarding.ApplicationCore.Entities;

namespace OnBoarding.Infrastructure.Data
{
	public class HRMDbContext : DbContext
	{
		public HRMDbContext(DbContextOptions<HRMDbContext> options) : base(options)
		{
		}

		public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeCategory> EmployeeCategories { get; set; }
        public DbSet<EmployeeStatus> EmployeeStatuses { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
    }
}

