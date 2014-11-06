namespace SampleDataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class EnumerableExtensions
    {
        private static readonly Random Rnd = new Random();

        public static T Random<T>(this IEnumerable<T> list)
        {
            return list.ElementAt(Rnd.Next(list.Count()));
        }

        public static IEnumerable<T> Loop<T>(this IEnumerable<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }

            if (!list.Any())
            {
                yield break;
            }

            var enumerator = list.GetEnumerator();

            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }

            var q = list.Loop().GetEnumerator();

            while (q.MoveNext())
            {
                yield return q.Current;
            }
        }
    }
}
