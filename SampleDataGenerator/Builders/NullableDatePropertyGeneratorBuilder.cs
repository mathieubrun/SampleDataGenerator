using System;
using System.Linq.Expressions;
using SampleDataGenerator.Generators;
using SampleDataGenerator.Sources;

namespace SampleDataGenerator.Builders
{
    public class NullableDatePropertyGeneratorBuilder<TObj> : PropertyGeneratorBuilder<TObj, DateTime?>, INullableDatePropertyGeneratorBuilder<TObj>
    {
        private readonly Random rnd = new Random();

        public NullableDatePropertyGeneratorBuilder(ObjectGeneratorBuilder<TObj> from, Expression<Func<TObj, DateTime?>> expr)
            : base(from, expr)
        {
        }

        public IObjectGeneratorBuilder<TObj> Range(DateTime start, DateTime end)
        {
            var pgen = new SourceGenerator<DateTime?>(new DateGenerator(start, end));

            return this.Add(pgen);
        }
    }
}