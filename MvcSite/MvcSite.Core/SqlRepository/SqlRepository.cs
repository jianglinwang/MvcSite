using System.Data.SqlClient;

namespace MvcSite.Core.SqlRepository
{
    public class SqlRepository: ISqlRepository
    {
        public SqlConnection Create()
        {
            return new SqlConnection("");
        }
    }
}
