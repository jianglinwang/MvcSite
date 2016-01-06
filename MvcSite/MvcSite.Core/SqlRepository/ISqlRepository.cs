using System.Data.SqlClient;

namespace MvcSite.Core.SqlRepository
{
    public interface ISqlRepository
    {
        SqlConnection Create();
    }
}
