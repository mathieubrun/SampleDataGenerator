using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace SampleDataGenerator.Builders
{
    public interface IObjectGeneratorBuilder<TObj>
    {
        IDatePropertyGeneratorBuilder<TObj> For(Expression<Func<TObj, DateTime>> propertyExpression);

        IArrayPropertyGeneratorBuilder<TObj, TProp> For<TProp>(Expression<Func<TObj, IEnumerable<TProp>>> propertyExpression);

        IPropertyGeneratorBuilder<TObj, TProp> For<TProp>(Expression<Func<TObj, TProp>> propertyExpression);
    }
}
