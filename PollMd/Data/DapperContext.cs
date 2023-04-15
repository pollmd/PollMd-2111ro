using Microsoft.Data.SqlClient;
using System.Data;

namespace PollMd.Data
{
    public class DapperContext
    {
        public IConfiguration _configuration { get; set; }
        public string _connectionString { get; set; }
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
        
    }
}
