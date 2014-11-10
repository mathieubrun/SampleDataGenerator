using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDataGenerator.Generators
{
    public class ObjectGeneratorGenerator<TProp> : IPropertyGenerator<TProp>
    {
        private readonly IObjectGenerator<TProp> generator;

        public ObjectGeneratorGenerator(IObjectGenerator<TProp> generator)
        {
            this.generator = generator;
        }

        public TProp Get()
        {
            return this.generator.Generate();
        }
    }
}
