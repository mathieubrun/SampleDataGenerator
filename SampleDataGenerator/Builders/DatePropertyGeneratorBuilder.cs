using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using SampleDataGenerator.Generators;
using SampleDataGenerator.Sources;

namespace SampleDataGenerator.Builders
{
    public class DatePropertyGeneratorBuilder<TObj> : PropertyGeneratorBuilder<TObj, DateTime>, IDatePropertyGeneratorBuilder<TObj>
    {
        public DatePropertyGeneratorBuilder(ObjectGeneratorBuilder<TObj> from, Expression<Func<TObj, DateTime>> expression)
            : base(from, expression)
        {
        }

        public DatePropertyGeneratorBuilder(ObjectGeneratorBuilder<TObj> from, Expression<Func<TObj, DateTime?>> expression)
            : base(from, GetSetter(expression))
        {
        }

        public IObjectGeneratorBuilder<TObj> Range(DateTime start, DateTime end)
        {
            var gen = new DateGenerator(start, end);
            var pgen = new FuncGenerator<DateTime>(() => gen.Generate());

            return this.Add(pgen);
        }
    }
}