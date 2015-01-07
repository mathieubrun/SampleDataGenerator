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

        public PropertyGeneratorBuilderBase(ObjectGeneratorBuilder<TObj> from)
        {
            this.builder = from;
        }

        public PropertyGeneratorBuilderBase(ObjectGeneratorBuilder<TObj> from, Expression<Func<TObj, TProp>> expr)
            : this(from)
        {
            this.Expr = GetSetter(expr);
        }

        protected Expression<Action<TObj, TProp>> Expr { get; set; }

        protected ObjectGeneratorBuilder<TObj> Add(IElementGenerator<TProp> build)
        {
            return this.builder.Add<TProp>(build, this.Expr);
        }

        private static Expression<Action<T, U>> GetSetter<T, U>(Expression<Func<T, U>> expression)
        {
            var b = expression.Body;
            if (b.NodeType == ExpressionType.Convert)
            {
                b = ((UnaryExpression)expression.Body).Operand;
            }

            var memberExpression = (MemberExpression)b;
            var property = (PropertyInfo)memberExpression.Member;
            var setMethod = property.GetSetMethod();

            var parameterT = Expression.Parameter(typeof(T), "x");
            var parameterU = Expression.Parameter(typeof(U), "y");

            var newExpression =
                Expression.Lambda<Action<T, U>>(
                    Expression.Call(parameterT, setMethod, parameterU),
                    parameterT,
                    parameterU);

            return newExpression;
        }
    }
}