using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SampleDataGenerator.Generators
{
    public class StringGenerator : IPropertyGenerator<string>
    {
        private static readonly Random Rnd = new Random();

        private readonly IEnumerable<string> source;
        private readonly int count;

        public StringGenerator(string[] source, int count)
        {
            this.source = source;
            this.count = count;
        }

        public string Get()
        {
            return string.Join(" ", this.source.OrderBy(x => Rnd.Next()).Take(count).ToArray());
        }
    }
}