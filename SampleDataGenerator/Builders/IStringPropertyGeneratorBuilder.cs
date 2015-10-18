using System;
using System.Linq.Expressions;

namespace SampleDataGenerator.Builders
{
    public interface IStringPropertyGeneratorBuilder<TObj> : IPropertyGeneratorBuilder<TObj, string>
    {
        IObjectGeneratorBuilder<TObj> LoremIpsum(int sentences);

        IObjectGeneratorBuilder<TObj> PhoneNumber(string pattern);

        IObjectGeneratorBuilder<TObj> Email(params Expression<Func<TObj, string>>[] sources);

        IObjectGeneratorBuilder<TObj> Website(params Expression<Func<TObj, string>>[] sources);
    }
}