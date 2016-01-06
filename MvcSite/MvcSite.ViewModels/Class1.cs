using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Attribute;

namespace MvcSite.ViewModels
{
    [GlobalResource(ClassKey="Website")]
    public class User
    {
        [GlobalResource(ResourceKey="UserName")]
        public string UserName { get; set; }
    }
}
