using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDataGenerator.Sources
{
    public class SequencialSource<TProp> : ISource<TProp>
    {
        private readonly TProp[] source;

        private IEnumerator<TProp> enumerator;

        public SequencialSource(params TProp[] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            this.source = source;

            this.enumerator = this.Loop(source).GetEnumerator();
        }

        public TProp Get()
        {
            this.enumerator.MoveNext();

            return this.enumerator.Current;
        }

        public IEnumerable<TProp> Get(int count)
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
