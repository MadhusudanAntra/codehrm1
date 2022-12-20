using Microsoft.EntityFrameworkCore;
using OnBoarding.ApplicationCore.Contracts.Repositories;
using OnBoarding.ApplicationCore.Contracts.Services;
using OnBoarding.Infrastructure.Data;
using OnBoarding.Infrastructure.Repositories;
using OnBoarding.Infrastructure.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmployeeCategoryRepository, EmployeeCategoryRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeRoleRepository, EmployeeRoleRepository>();
builder.Services.AddScoped<IEmployeeStatusRepository, EmployeeStatusRepository>();
builder.Services.AddScoped<IEmployeeCategoryService, EmployeeCategoryService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRoleService, EmployeeRoleService>();
builder.Services.AddScoped<IEmployeeStatusService, EmployeeStatusService>();

builder.Services.AddDbContext<HRMDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLDB")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();