using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using WebSite.Attribute;

namespace WebSite.GlobalHelper
{
    public static class GlobalHelper
    {
        public static string GetGlobalString(string classKey, string resourceKey, CultureInfo culture)
        {
            return HttpContext.GetGlobalResourceObject(classKey, resourceKey, culture).ToString();
        }

        public static string GetGlobalResource(Type type, PropertyInfo property, CultureInfo culture)
        {
            var classKey= (GlobalResourceAttribute)type.GetCustomAttribute(typeof(GlobalResourceAttribute), false);
            var pro = (GlobalResourceAttribute)property.GetCustomAttribute(typeof(GlobalResourceAttribute), false);
            return HttpContext.GetGlobalResourceObject(classKey.ClassKey, pro.ResourceKey, culture).ToString();
        }
    }
}