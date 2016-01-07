using MvcSite.Dal;
using MvcSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebSite.Models
{
    public class UserModel
    {
        UserDal userDal = new UserDal();

        public async Task<List<User>> GetUserList()
        {
            var result = new List<User>();
            var dt = await userDal.GetUserList();
            foreach (DataRow item in dt.Rows)
            {
                result.Add(new User { UserName = item["customerid"].ToString() });
            }
            return result;
        }
    }
}