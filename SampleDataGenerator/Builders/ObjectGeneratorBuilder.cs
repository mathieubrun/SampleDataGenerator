﻿namespace SampleDataGenerator.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class ObjectGeneratorBuilder<TObj> : IObjectGenerator<TObj>
    {
        private ObjectGenerator<TObj> generator;

        public ObjectGeneratorBuilder()
        {
            this.generator = new ObjectGenerator<TObj>();
        }

        public PropertyGeneratorBuilder<TObj, TProp> For<TProp>(Expression<Func<TObj, TProp>> propertyExpression)
        {
            return new PropertyGeneratorBuilder<TObj, TProp>(this, propertyExpression);
        }

        public ArrayPropertyGeneratorBuilder<TObj, TProp> For<TProp>(Expression<Func<TObj, IEnumerable<TProp>>> propertyExpression)
        {
            return new ArrayPropertyGeneratorBuilder<TObj, TProp>(this, propertyExpression);
        }

        public DatePropertyGeneratorBuilder<TObj> For(Expression<Func<TObj, DateTime>> propertyExpression)
        {
            return new DatePropertyGeneratorBuilder<TObj>(this, propertyExpression);
        }

        public TObj Generate()
        {
            return this.Generate(1).First();
        }

        public IEnumerable<TObj> Generate(int count)
        {
            return this.generator.Generate(count);
        }

        internal ObjectGeneratorBuilder<TObj> Add<TProp>(IPropertyGenerator<TProp> build, Expression<Func<TObj, TProp>> propertyExpression)
        {
            this.generator.Add(build, propertyExpression);

            return this;
        }
    }
}