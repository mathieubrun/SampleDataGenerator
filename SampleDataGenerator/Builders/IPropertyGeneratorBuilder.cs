using System;
using System.Linq.Expressions;
namespace SampleDataGenerator.Builders
{
    public interface IPropertyGeneratorBuilder<TObj, TProp>
    {
        IObjectGeneratorBuilder<TObj> ChooseFrom(params TProp[] list);

        IObjectGeneratorBuilder<TObj> ChooseRandomlyFrom(params TProp[] list);

        IObjectGeneratorBuilder<TObj> CreateUsing(IObjectGenerator<TProp> generator);

        IObjectGeneratorBuilder<TObj> CreateUsing(Expression<Func<TProp>> ee);
    }
}
