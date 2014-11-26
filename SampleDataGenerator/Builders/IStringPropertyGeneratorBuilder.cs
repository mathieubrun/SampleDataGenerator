using System;
using System.Linq.Expressions;

namespace SampleDataGenerator.Builders
{
    public interface IStringPropertyGeneratorBuilder<TObj> : IPropertyGeneratorBuilder<TObj, string>
    {        
        IObjectGeneratorBuilder<TObj> LoremIpsum(int sentences);
    }
}