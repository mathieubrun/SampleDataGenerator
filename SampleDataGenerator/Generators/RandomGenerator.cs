using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDataGenerator.Generators
{
    public class RandomGenerator<TProp> : IPropertyGenerator<TProp>
    {
        private readonly IEnumerable<TProp> source;

        public RandomGenerator(params TProp[] source)
        {
            this.source = source;
        }

        public TProp Get()
        {
            return this.source.Random();
        }
    }
}
