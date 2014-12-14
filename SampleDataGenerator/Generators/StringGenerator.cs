using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SampleDataGenerator.Sources;

namespace SampleDataGenerator.Generators
{
    public class JoinedStringGenerator : SourceGenerator<string>
    {
        private readonly int count;
        private readonly string separator;

        public JoinedStringGenerator(ISource<string> source, int count, string separator)
            : base(source)
        {
            this.count = count;
            this.separator = separator;
        }

        public override string Get()
        {
            return string.Join(separator, this.Source.Generate(count).ToArray());
        }
    }
}