namespace SampleDataGenerator.Builders
{
    using System;
    using System.Linq.Expressions;

    public class PropertyGeneratorBuilderBase<TObj, TProp>
    {
        private readonly ObjectGeneratorBuilder<TObj> builder;
        private readonly Expression<Func<TObj, TProp>> expr;

        public PropertyGeneratorBuilderBase(ObjectGeneratorBuilder<TObj> from, Expression<Func<TObj, TProp>> expr)
        {
            this.expr = expr;
            this.builder = from;
        }

        protected ObjectGeneratorBuilder<TObj> Add(IPropertyGenerator<TProp> build)
        {
            return this.builder.Add<TProp>(build, this.expr);
        }
    }
}