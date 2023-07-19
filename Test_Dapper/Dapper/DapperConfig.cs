using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Test_Dapper.Dapper
{
    public class DapperConfig
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperConfig(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
