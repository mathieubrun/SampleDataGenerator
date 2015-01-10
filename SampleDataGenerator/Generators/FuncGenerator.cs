using System;
using System.Linq.Expressions;
using SampleDataGenerator.Sources;

namespace SampleDataGenerator.Generators
{
    public class FuncGenerator<TProp> : IElementGenerator<TProp>
    {
        private readonly Func<TProp> func;

        public FuncGenerator(Expression<Func<TProp>> expr)
        {
            this.func = expr.Compile();
        }

        public TProp Generate()
        {
            return this.func();
        }
    }
}