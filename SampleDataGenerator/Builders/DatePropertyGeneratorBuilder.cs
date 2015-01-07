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
        public DatePropertyGeneratorBuilder(ObjectGeneratorBuilder<TObj> from, Expression<Func<TObj, DateTime>> expr)
            : base(from, expr)
        {
        }

        public DatePropertyGeneratorBuilder(ObjectGeneratorBuilder<TObj> from, Expression<Func<TObj, DateTime?>> expr)
            : base(from)
        {
            var memberExpression = (MemberExpression)expr.Body;
            var property = (PropertyInfo)memberExpression.Member;
            var setMethod = property.GetSetMethod();

            var objectParameter = Expression.Parameter(typeof(TObj), "x");
            var propertyParameter = Expression.Parameter(typeof(DateTime), "y");

            var cast = Expression.TypeAs(propertyParameter, typeof(DateTime?));

            var newEpxression =
                Expression.Lambda<Action<TObj, DateTime>>(
                    Expression.Call(objectParameter, setMethod, cast),
                    objectParameter,
                    propertyParameter);

            this.Expr = newEpxression;
        }

        public IObjectGeneratorBuilder<TObj> Range(DateTime start, DateTime end)
        {
            var gen = new DateGenerator(start, end);
            var pgen = new FuncGenerator<DateTime>(() => gen.Generate());

            return this.Add(pgen);
        }
    }
}