
using Microsoft.Data.SqlClient;
using System.Data;

namespace Dapper.Demo.Dal.Database
{
    public class DapperContext
    {
        private readonly string _connectionString;

        public DapperContext(string connectionString) {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection() => new SqlConnection(this._connectionString);

        
    }
}
