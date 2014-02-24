using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class IEnumerableExtensions
    {

        public static string JoinToString(this IEnumerable collection, char separator)
        {
            var sb = new StringBuilder();

            foreach (var item in collection)
            {
                sb.Append(item.ToString());
                sb.Append(separator);
                                
            }

            return sb.ToString().SafeSubstring(0, sb.ToString().Length - 1);
            
        }


        public static T PickRandom<T>(this IEnumerable<T> source)
        {
            return source.PickRandom(1).Single();
        }

        public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count)
        {
            return source.Shuffle().Take(count);
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.OrderBy(x => Guid.NewGuid());
        }

    }
}
