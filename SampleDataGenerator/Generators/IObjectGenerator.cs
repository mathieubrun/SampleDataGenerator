using System.Collections.Generic;

namespace SampleDataGenerator.Generators
{
    public interface IObjectGenerator<TObj>
    {
        TObj Generate();

        IEnumerable<TObj> Generate(int count);
    }
}