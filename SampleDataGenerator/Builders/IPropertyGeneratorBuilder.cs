using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SampleDataGenerator.Generators;

namespace SampleDataGenerator.Builders
{
    public interface IPropertyGeneratorBuilder<TObj, TProp>
    {
        IObjectGeneratorBuilder<TObj> ChooseFrom(params TProp[] list);

        IObjectGeneratorBuilder<TObj> ChooseFrom(IEnumerable<TProp> list);

        IObjectGeneratorBuilder<TObj> ChooseRandomlyFrom(params TProp[] list);

        IObjectGeneratorBuilder<TObj> ChooseRandomlyFrom(IEnumerable<TProp> list);

        IObjectGeneratorBuilder<TObj> CreateUsing(IObjectGenerator<TProp> generator);

        IObjectGeneratorBuilder<TObj> CreateUsing(Expression<Func<TProp>> expression);
    }
}