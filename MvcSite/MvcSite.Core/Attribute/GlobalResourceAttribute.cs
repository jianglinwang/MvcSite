using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcSite.Core.Attribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple= true, Inherited=true)]
    public class GlobalResourceAttribute : System.Attribute
    {
        public string ClassKey { get; set; }
        public string ResourceKey { get; set; }
    }
}