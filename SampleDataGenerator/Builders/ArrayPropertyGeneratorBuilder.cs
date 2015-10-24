using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SampleDataGenerator.Generators;

namespace SampleDataGenerator.Builders
{
    public class ArrayPropertyGeneratorBuilder<TObj, TProp> : PropertyGeneratorBuilderBase<TObj, IEnumerable<TProp>>, IArrayPropertyGeneratorBuilder<TObj, TProp>
    {
        public ArrayPropertyGeneratorBuilder(ObjectGeneratorBuilder<TObj> from, Expression<Func<TObj, IEnumerable<TProp>>> expression)
            : base(from, expression)
        {
        }

        public IObjectGeneratorBuilder<TObj> CreateUsing(IObjectGenerator<TProp> generator, int count)
        {
            var pgen = new FuncGenerator<IEnumerable<TProp>>(() => generator.Generate(count).ToArray());

            return this.Add(pgen);
        }
    }
}