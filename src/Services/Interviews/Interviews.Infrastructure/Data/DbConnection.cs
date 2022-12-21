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
        //string conn = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("HRM_Interview");
        string conn = _configuration.GetConnectionString("HRM_Interview");
        return new SqlConnection(conn);
    }


}