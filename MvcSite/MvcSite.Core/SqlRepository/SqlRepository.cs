using System.Configuration;
using System.Data.SqlClient;

namespace MvcSite.Core.SqlRepository
{
    public class SqlRepository : ISqlRepository
    {
        public string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["website"].ConnectionString; }
        }

        public SqlConnection Create()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
