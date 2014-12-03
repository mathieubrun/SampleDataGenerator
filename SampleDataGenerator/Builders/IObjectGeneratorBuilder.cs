using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SampleDataGenerator.Generators;

namespace SampleDataGenerator.Builders
{
    public interface IObjectGeneratorBuilder<TObj> : IObjectGenerator<TObj>
    {
        IArrayPropertyGeneratorBuilder<TObj, TProp> For<TProp>(Expression<Func<TObj, IEnumerable<TProp>>> propertyExpression);

        INullableDatePropertyGeneratorBuilder<TObj> For(Expression<Func<TObj, DateTime?>> propertyExpression);

        IDatePropertyGeneratorBuilder<TObj> For(Expression<Func<TObj, DateTime>> propertyExpression);

        IStringPropertyGeneratorBuilder<TObj> For(Expression<Func<TObj, string>> propertyExpression);

        IPropertyGeneratorBuilder<TObj, TProp> For<TProp>(Expression<Func<TObj, TProp>> propertyExpression);
    }
}