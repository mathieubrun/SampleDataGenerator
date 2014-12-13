using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleDataGenerator.Sources
{
    public class RandomSource<TProp> : ISource<TProp>
    {
        private static readonly Random Rnd = new Random();

        private readonly TProp[] source;

        public RandomSource(params TProp[] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            this.source = source;
        }

        public TProp Generate()
        {
            if (!source.Any())
            {
                return default(TProp);
            }

            return this.source[Rnd.Next(this.source.Length)];
        }

        public IEnumerable<TProp> Generate(int count)
        {
            // TODO : optimize
            return this.Loop().Take(count);
        }

        private IEnumerable<TProp> Loop()
        {
            var list = this.source.OrderBy(x => Rnd.Next());

            var enumerator = list.GetEnumerator();

            if (!list.Any())
            {
                yield break;
            }

            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }

            var q = this.Loop().GetEnumerator();

            while (q.MoveNext())
            {
                yield return q.Current;
            }
        }
    }
}