using System.Collections.Generic;
using System.Linq;

namespace Insurance.Common
{
    public static class ListExtensions
    {
        public static bool IsEmpty<T>(this IList<T> list)
        {
            return list == null || !list.Any();
        }
    }
}
