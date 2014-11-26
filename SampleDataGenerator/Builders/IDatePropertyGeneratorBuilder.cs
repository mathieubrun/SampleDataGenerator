using System;

namespace SampleDataGenerator.Builders
{
    public interface IDatePropertyGeneratorBuilder<TObj> : IPropertyGeneratorBuilder<TObj, DateTime>
    {
        IObjectGeneratorBuilder<TObj> Range(DateTime start, DateTime end);
    }
}