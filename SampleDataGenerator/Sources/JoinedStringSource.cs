using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SampleDataGenerator.Sources;

namespace SampleDataGenerator.Sources
{
    public class JoinedStringSource : IElementGenerator<string>
    {
        private readonly int count;
        private readonly string separator;
        private readonly IElementEnumerableGenerator<string> source;

        public JoinedStringSource(IElementEnumerableGenerator<string> source, int count, string separator)
        {
            this.source = source;
            this.count = count;
            this.separator = separator;
        }

        public string Generate()
        {
            return string.Join(separator, this.source.Generate(count).ToArray());
        }
    }
}