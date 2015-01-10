using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDataGenerator.Sources
{
    /// <summary>
    /// Exposes a data generator for a given data type
    /// </summary>
    /// <typeparam name="TProp">Source data type</typeparam>
    public interface IElementGenerator<out TProp>
    {
        /// <summary>
        /// Generates one element
        /// </summary>
        /// <returns>One element of given data type</returns>
        TProp Generate();
    }
}
