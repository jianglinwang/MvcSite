using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcSite.Core.Extension
{
    public static class IEnumerableExtension
    {
        public static void ForEach<T>(this IEnumerable<T> ite, Action<T, int> action)
        {
            for (int i = 0; i < ite.Count(); i++)
            {
                action(ite.ElementAt(i), i);
            }
        }
    }
}
