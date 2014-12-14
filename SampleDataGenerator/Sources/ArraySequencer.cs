using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDataGenerator.Sources
{
    public class ArraySequencer<TProp> : IElementGenerator<TProp>
    {
        private readonly TProp[] source;

        private IEnumerator<TProp> enumerator;

        public ArraySequencer(params TProp[] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            this.source = source;

            this.enumerator = this.Loop(source).GetEnumerator();
        }

        public TProp Generate()
        {
            this.enumerator.MoveNext();

            return this.enumerator.Current;
        }

        public IEnumerable<TProp> Generate(int count)
        {
            while (count-- > 0)
            {
                this.enumerator.MoveNext();

                yield return this.enumerator.Current;
            }
        }

        protected IEnumerable<T> Loop<T>(IEnumerable<T> list)
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

            var q = this.Loop(list).GetEnumerator();

            while (q.MoveNext())
            {
                yield return q.Current;
            }
        }
    }
}
