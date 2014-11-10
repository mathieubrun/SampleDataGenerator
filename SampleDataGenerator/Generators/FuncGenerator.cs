using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SampleDataGenerator.Generators
{
    public class FuncGenerator<TProp> : IPropertyGenerator<TProp>
    {
        private readonly Func<TProp> func;

        public FuncGenerator(Expression<Func<TProp>> expr)
        {
            this.func = expr.Compile();
        }

        public TProp Get()
        {
            return this.func();
        }
    }
}
