using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDataGenerator.Generators
{
    public class SequencialGenerator<TProp> : IPropertyGenerator<TProp>
    {
        private readonly IEnumerable<TProp> source;
        private IEnumerator<TProp> enumerator;

        public SequencialGenerator(params TProp[] source)
        {
            this.source = source;

            enumerator = source.Loop().GetEnumerator();
        }

        public TProp Get()
        {
            enumerator.MoveNext();
            return enumerator.Current;
        }
    }
}
