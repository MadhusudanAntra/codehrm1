using Microsoft.EntityFrameworkCore;
using Recruiting.API.CustomMiddleware;
using Recruiting.ApplicationCore.Contracts.Repositories;
using Recruiting.ApplicationCore.Contracts.Services;
using Recruiting.Infrastructure.Data;
using Recruiting.Infrastructure.Repositories;
using Recruiting.Infrastructure.Services;
using Serilog;
using Serilog.Events;
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

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .Enrich.WithExceptionDetails()
    .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information).WriteTo.File("SubmissionLogs.json", rollingInterval: RollingInterval.Day))
    .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Error).WriteTo.File("ExceptionLogs.json", rollingInterval: RollingInterval.Day))
    .CreateLogger();
builder.Host.UseSerilog(Log.Logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandler>();

app.UseSerilogRequestLogging();

app.MapControllers();

app.Run();