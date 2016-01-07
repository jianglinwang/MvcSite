using MvcSite.Core.SqlRepository;
using System.Data;
using System.Threading.Tasks;

namespace MvcSite.Dal
{
    public class UserDal
    {
        internal ISqlRepository SqlRepository { get { return new SqlRepository(); } }

        public async Task<DataTable> GetUserList()
        {
            var dt = new DataTable();
            await SqlRepository.ExecuteStoredProcedure("sp_all_customer_G", dt);
            return dt;
        }
    }
}
