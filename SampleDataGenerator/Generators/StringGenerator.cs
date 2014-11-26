using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SampleDataGenerator.Sources;

namespace SampleDataGenerator.Generators
{
    public class StringGenerator : IPropertyGenerator<string>
    {
        private readonly ISource<string> source;
        private readonly int count;

        public StringGenerator(ISource<string> source, int count)
        {
            this.source = source;
            this.count = count;
        }

        public string Get()
        {
            return string.Join(" ", this.source.Get(count).ToArray());
        }
    }
}