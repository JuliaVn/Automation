using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dapper_Tests
{
    class BaseContext
    {
        private readonly string connStr = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True";

        protected IEnumerable<dynamic> PerformQuery(string sql)
        {
            using (var connection = new SqlConnection(connStr))
            {
                return connection.Query(sql);
            }
        }
        protected IEnumerable<T> PerformQuery<T>(string sql)
        {
            using (var connection = new SqlConnection(connStr))
            {
                return connection.Query<T>(sql);
            }
        }
    }
}
