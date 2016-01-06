using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace WebSite.GlobalHelper
{
    public static class GlobalHelper
    {
        public static string GetGlobalString(string classKey, string resourceKey, CultureInfo culture)
        {
            return HttpContext.GetGlobalResourceObject(classKey, resourceKey, culture).ToString();
        }
    }
}