using System;
using System.Collections.Generic;
using System.Linq;
using SampleDataGenerator.Sources;

namespace SampleDataGenerator.Generators
{
    public class SourceGenerator<TProp> : IPropertyGenerator<TProp>
    {
        private readonly ISource<TProp> source;

        public SourceGenerator(ISource<TProp> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            this.source = source;
        }

        protected ISource<TProp> Source
        {
            get
            {
                return source;
            }
        }

        public virtual TProp Get()
        {
            return this.source.Generate();
        }
    }
}