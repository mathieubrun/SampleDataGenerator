using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleDataGenerator.Generators
{
    public class RandomGenerator<TProp> : IPropertyGenerator<TProp>
    {
        private static readonly Random Rnd = new Random();

        private readonly IEnumerable<TProp> source;

        public RandomGenerator(params TProp[] source)
        {
            this.source = source;
        }

        public TProp Get()
        {
            return this.source.ElementAt(Rnd.Next(this.source.Count()));
        }
    }
}