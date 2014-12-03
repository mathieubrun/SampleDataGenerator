using System;

namespace SampleDataGenerator.Builders
{
    public interface INullableDatePropertyGeneratorBuilder<TObj> : IPropertyGeneratorBuilder<TObj, DateTime?>
    {
        IObjectGeneratorBuilder<TObj> Range(DateTime start, DateTime end);
    }
}