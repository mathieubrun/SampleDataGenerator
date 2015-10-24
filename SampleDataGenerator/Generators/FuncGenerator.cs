using System;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using SampleDataGenerator.Sources;

namespace SampleDataGenerator.Generators
{
    public class FuncGenerator<TProp> : IElementGenerator<TProp>
    {
        private readonly Func<TProp> getter;

        public FuncGenerator(Expression<Func<TProp>> expression)
        {
            Contract.Requires(expression != null);

            this.getter = expression.Compile();
        }

        public TProp Generate()
        {
            return this.getter();
        }
    }
}