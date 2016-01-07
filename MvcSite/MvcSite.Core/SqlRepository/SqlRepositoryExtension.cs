using System.Data;
using System.Data.SqlClient;
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

                    var adapter = new SqlDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                }
                finally { conn.Close(); }
            }
        }

        public static async Task Execute(this ISqlRepository repository, string name)
        {
            using (var conn = repository.Create())
            {
                var transaction = conn.BeginTransaction();

                var sqlCommand = conn.CreateCommand();
                sqlCommand.CommandText = name;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Transaction = transaction;

                try
                {
                    await conn.OpenAsync();
                    await sqlCommand.ExecuteNonQueryAsync();
                    transaction.Commit();
                }
                catch
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
