using System;
using System.Linq.Expressions;

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