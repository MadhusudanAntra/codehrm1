using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Interviews.Infrastructure.Data;

public class DbConnection
{
    private readonly IConfiguration _configuration;

    public DbConnection(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public SqlConnection GetConnection()
    {
        //var conn = _configuration.GetConnectionString("HRM_Interview");
        var conn = Environment.GetEnvironmentVariable("MSSQLConnectionString");
        return new SqlConnection(conn);
    }


}