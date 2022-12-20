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
        return new SqlConnection("Server=localhost;Database=HRM_Interview;User Id=sa;Password=Antra123!;TrustServerCertificate=true");
    }
}