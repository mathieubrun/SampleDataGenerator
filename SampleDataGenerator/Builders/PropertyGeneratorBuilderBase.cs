using System;
using System.Linq.Expressions;
using System.Reflection;
using SampleDataGenerator.Generators;
using SampleDataGenerator.Sources;

namespace SampleDataGenerator.Builders
{
    public class PropertyGeneratorBuilderBase<TObj, TProp>
    {
        private readonly ObjectGeneratorBuilder<TObj> builder;
        private readonly Expression<Action<TObj, TProp>> expr;

        public PropertyGeneratorBuilderBase(ObjectGeneratorBuilder<TObj> from, Expression<Func<TObj, TProp>> expr)
        {
            this.builder = from;
            this.expr = GetSetter(expr);
        }

        protected PropertyGeneratorBuilderBase(ObjectGeneratorBuilder<TObj> from, Expression<Action<TObj, TProp>> expr)
        {
            this.builder = from;
            this.expr = expr;
        }

        protected static Expression<Action<TObj, TProp>> GetSetter<T>(Expression<Func<TObj, T>> expr)
        {
            var memberExpression = (MemberExpression)expr.Body;
            var property = (PropertyInfo)memberExpression.Member;
            var setMethod = property.GetSetMethod();

            var objectParameter = Expression.Parameter(typeof(TObj));
            var propertyParameter = Expression.Parameter(typeof(TProp));

            var cast = Expression.TypeAs(propertyParameter, typeof(T));

            var newEpxression =
                Expression.Lambda<Action<TObj, TProp>>(
                    Expression.Call(objectParameter, setMethod, cast),
                    objectParameter,
                    propertyParameter);

            return newEpxression;
        }

        protected ObjectGeneratorBuilder<TObj> Add(IElementGenerator<TProp> build)
        {
            return this.builder.Add<TProp>(build, expr);
        }

        private static Expression<Action<TObj, TProp>> GetSetter(Expression<Func<TObj, TProp>> expression)
        {
            var memberExpression = (MemberExpression)expression.Body;
            var property = (PropertyInfo)memberExpression.Member;
            var setMethod = property.GetSetMethod();

            var objectParameter = Expression.Parameter(typeof(TObj));
            var propertyParameter = Expression.Parameter(typeof(TProp));

            var newExpression =
                Expression.Lambda<Action<TObj, TProp>>(
                    Expression.Call(objectParameter, setMethod, propertyParameter),
                    objectParameter,
                    propertyParameter);

            return newExpression;
        }
    }
}