using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcSite.Core.SqlRepository
{
    public static class SqlRepositoryExtension
    {
        public static async Task ExecuteStoredProcedure(this ISqlRepository repository, string procedureName, DataTable dt)
        {
            using (var conn = repository.Create())
            {
                var sqlCommand = conn.CreateCommand();
                sqlCommand.CommandText = procedureName;
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    await conn.OpenAsync();

                    await sqlCommand.ExecuteNonQueryAsync();

                    var adapter = new SqlDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                }
                finally { conn.Close(); }
            }
        }
    }
}
