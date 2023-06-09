using Authentication.API;
using Authentication.API.Data;
using Authentication.API.Entities;
using Authentication.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var MSSQLDB = Environment.GetEnvironmentVariable("MSSQLConnectionString");

builder.Services.AddDbContext<AuthenticationDbContext>(options => options.UseSqlServer(MSSQLDB));

builder.Services.AddScoped<IAuthenticationService<User>, AuthenticationService>();

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<AuthenticationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();