using System;
using System.Linq.Expressions;
using SampleDataGenerator.Generators;
using SampleDataGenerator.Sources;

namespace SampleDataGenerator.Builders
{
    public class NullableDatePropertyGeneratorBuilder<TObj> : PropertyGeneratorBuilder<TObj, DateTime?>, INullableDatePropertyGeneratorBuilder<TObj>
    {
        public NullableDatePropertyGeneratorBuilder(ObjectGeneratorBuilder<TObj> from, Expression<Func<TObj, DateTime?>> expr)
            : base(from, expr)
        {
        }

        public IObjectGeneratorBuilder<TObj> Range(DateTime start, DateTime end)
        {
            var gen = new DateGenerator(start, end);

            var pgen = new FuncGenerator<DateTime?>(() => gen.Generate());

            return this.Add(pgen);
        }
    }
}