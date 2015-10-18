using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SampleDataGenerator.Generators;
using SampleDataGenerator.Sources;

namespace SampleDataGenerator.Builders
{
    public class ObjectGeneratorBuilder<TObj> : IObjectGenerator<TObj>, IObjectGeneratorBuilder<TObj>
    {
        public ObjectGeneratorBuilder()
        {
            this.Generator = new ObjectGenerator<TObj>();
        }

        public ObjectGenerator<TObj> Generator { get; set; }

        public IPropertyGeneratorBuilder<TObj, TProp> For<TProp>(Expression<Func<TObj, TProp>> propertyExpression)
        {
            return new PropertyGeneratorBuilder<TObj, TProp>(this, propertyExpression);
        }

        public IArrayPropertyGeneratorBuilder<TObj, TProp> For<TProp>(Expression<Func<TObj, IEnumerable<TProp>>> propertyExpression)
        {
            return new ArrayPropertyGeneratorBuilder<TObj, TProp>(this, propertyExpression);
        }

        public IDatePropertyGeneratorBuilder<TObj> For(Expression<Func<TObj, DateTime?>> propertyExpression)
        {
            return new DatePropertyGeneratorBuilder<TObj>(this, propertyExpression);
        }

        public IDatePropertyGeneratorBuilder<TObj> For(Expression<Func<TObj, DateTime>> propertyExpression)
        {
            return new DatePropertyGeneratorBuilder<TObj>(this, propertyExpression);
        }

        public IStringPropertyGeneratorBuilder<TObj> For(Expression<Func<TObj, string>> propertyExpression)
        {
            return new StringPropertyGeneratorBuilder<TObj>(this, propertyExpression);
        }

        public TObj Generate()
        {
            return this.Generator.Generate();
        }

        public IEnumerable<TObj> Generate(int count)
        {
            return this.Generator.Generate(count);
        }

        internal ObjectGeneratorBuilder<TObj> Add<TProp>(IElementGenerator<TProp> build, Expression<Action<TObj, TProp>> propertyExpression)
        {
            this.Generator.Add(build, propertyExpression);

            return this;
        }

        internal ObjectGeneratorBuilder<TObj> Add<TProp>(IDependentElementGenerator<TObj, TProp> build, Expression<Action<TObj, TProp>> propertyExpression)
        {
            this.Generator.Add(build, propertyExpression);

            return this;
        }
    }
}