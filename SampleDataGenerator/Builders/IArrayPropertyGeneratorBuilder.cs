using System;

namespace SampleDataGenerator.Builders
{
    public interface IArrayPropertyGeneratorBuilder<TObj, TProp>
    {
        IObjectGeneratorBuilder<TObj> CreateUsing(IObjectGenerator<TProp> generator, int count);
    }
}
