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
        private readonly string separator;

        public StringGenerator(ISource<string> source)
        {
            this.source = source;
        }

        public StringGenerator(ISource<string> source, int count, string separator)
            : this(source)
        {
            this.count = count;
            this.separator = separator;
        }

        public string Get()
        {
            if (count == 0)
            {
                return source.Get();
            }
            
            return string.Join(separator, this.source.Get(count).ToArray());
        }
    }
}