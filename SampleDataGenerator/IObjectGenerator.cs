namespace SampleDataGenerator
{
    using System.Collections.Generic;

    public interface IObjectGenerator<TObj>
    {
        TObj Generate();

        IEnumerable<TObj> Generate(int count);
    }
}