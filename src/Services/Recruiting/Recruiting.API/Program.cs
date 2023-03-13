using Microsoft.EntityFrameworkCore;
using Recruiting.ApplicationCore.Contracts.Repositories;
using Recruiting.ApplicationCore.Contracts.Services;
using Recruiting.Infrastructure.Data;
using Recruiting.Infrastructure.Repositories;
using Recruiting.Infrastructure.Services;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.File;


var allowedOrigins = "_allowedOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
builder.Services.AddScoped<ICandidateService, CandidateService>();

builder.Services.AddScoped<IJobRequirementRepository, JobRequirementRepository>();
builder.Services.AddScoped<IJobRequirementService, JobRequirementService>();

builder.Services.AddScoped<ISubmissionRepository, SubmissionRepository>();
builder.Services.AddScoped<ISubmissionService, SubmissionService>();

builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<IStatusService, StatusService>();

builder.Services.AddScoped<IEmployeeTypeRepository, EmployeeTypeRepository>();
builder.Services.AddScoped<IEmployeeTypeService, EmployeeTypeService>();

//var dockerRelated = Environment.GetEnvironmentVariable("MSSQLConnectionString");
var dockerRelated = builder.Configuration.GetConnectionString("RecruitingDb");
    
builder.Services.AddDbContext<RecruitingDbContext>(option => {
    option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    option.UseSqlServer(dockerRelated);
    //option.UseSqlServer(builder.Configuration.GetConnectionString("RecruitingDb"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedOrigins,
        builder =>
        {
            builder.WithOrigins("https://localhost:4200");
        });
});


var RedisConnectionString = Environment.GetEnvironmentVariable("RedisConnectionString");

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = RedisConnectionString;
});

var exceptionLogger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .Enrich.WithExceptionDetails()
    .WriteTo.File("exceptionLog.json", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var filterLogger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.File("filterLog.json", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();