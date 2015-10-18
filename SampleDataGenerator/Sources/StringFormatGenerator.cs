using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SampleDataGenerator.Sources
{
    public class StringFormatGenerator<TObj> : IDependentElementGenerator<TObj, string>
    {
        private readonly IEnumerable<Func<TObj, string>> sources;
        private readonly string format;
        private readonly Func<string, string> transform;

        public StringFormatGenerator(string format, params Expression<Func<TObj, string>>[] sources)
        {
            this.transform = x => x;
            this.format = format;
            this.sources = sources.Select(x => x.Compile());
        }

        public StringFormatGenerator(string format, Func<string, string> transform, params Expression<Func<TObj, string>>[] sources)
        {
            this.transform = transform;
            this.format = format;
            this.sources = sources.Select(x => x.Compile());
        }

        public string Generate(TObj obj)
        {
            return string.Format(format, sources.Select(x => transform(x(obj))).ToArray());
        }
    }
}