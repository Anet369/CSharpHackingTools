using System.Collections.Generic;
using System.Linq;

namespace SubdomainEnumerator.Extensions
{
    public static class StringListExtensions
    {
        public static IEnumerable<string> Sort(this IEnumerable<string> list)
        {
            return list.OrderBy(x => x);
        }
    }
}