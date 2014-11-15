﻿using System;
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
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            this.source = source;

            enumerator = Loop(source).GetEnumerator();
        }

        public TProp Get()
        {
            enumerator.MoveNext();
            return enumerator.Current;
        }

        public static IEnumerable<T> Loop<T>(IEnumerable<T> list)
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

            var q = Loop(list).GetEnumerator();

            while (q.MoveNext())
            {
                yield return q.Current;
            }
        }
    }
}