using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDataGenerator
{
    public interface IObjectGenerator<TObj>
    {
        TObj Generate();
        IEnumerable<TObj> Generate(int count);
    }
}
