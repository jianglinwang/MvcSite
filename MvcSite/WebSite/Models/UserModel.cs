using MvcSite.Dal;
using MvcSite.ViewModels;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models
{
    public class UserModel
    {

        public UserDal UserDal
        {
            get { return new UserDal(); }
        }

        public async Task<List<User>> GetUserList()
        {
            var dt = await UserDal.GetUserList();

            return (from DataRow item in dt.Rows
                    select new User { UserName = item["customerid"].ToString() }).ToList();
        }
    }
}