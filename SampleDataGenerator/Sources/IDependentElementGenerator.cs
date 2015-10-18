using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDataGenerator.Sources
{
    public interface IDependentElementGenerator<TObj, TProp>
    {
        TProp Generate(TObj obj);
    }
}
