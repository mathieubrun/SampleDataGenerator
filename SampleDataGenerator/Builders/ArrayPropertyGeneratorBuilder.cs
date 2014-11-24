namespace SampleDataGenerator.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using SampleDataGenerator.Generators;

    public class ArrayPropertyGeneratorBuilder<TObj, TProp> : PropertyGeneratorBuilderBase<TObj, IEnumerable<TProp>>, IArrayPropertyGeneratorBuilder<TObj,TProp>
    {
        public ArrayPropertyGeneratorBuilder(ObjectGeneratorBuilder<TObj> from, Expression<Func<TObj, IEnumerable<TProp>>> expr)
            : base(from, expr)
        {
        }

        public IObjectGeneratorBuilder<TObj> CreateUsing(IObjectGenerator<TProp> generator, int count)
        {
            var pgen = new FuncGenerator<IEnumerable<TProp>>(() => generator.Generate(count).ToArray());

            return this.Add(pgen);
        }
    }
}