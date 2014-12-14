using System;
using System.Linq.Expressions;
using SampleDataGenerator.Generators;
using SampleDataGenerator.Sources;

namespace SampleDataGenerator.Builders
{
    public class PropertyGeneratorBuilder<TObj, TProp> : PropertyGeneratorBuilderBase<TObj, TProp>, IPropertyGeneratorBuilder<TObj, TProp>
    {
        public PropertyGeneratorBuilder(ObjectGeneratorBuilder<TObj> from, Expression<Func<TObj, TProp>> expr)
            : base(from, expr)
        {
        }

        public IObjectGeneratorBuilder<TObj> ChooseFrom(params TProp[] list)
        {
            var pgen = new SourceGenerator<TProp>(new ArraySequencer<TProp>(list));

            return this.Add(pgen);
        }

        public IObjectGeneratorBuilder<TObj> ChooseRandomlyFrom(params TProp[] list)
        {
            var pgen = new SourceGenerator<TProp>(new ArrayRandomizer<TProp>(list));

            return this.Add(pgen);
        }

        public IObjectGeneratorBuilder<TObj> CreateUsing(Expression<Func<TProp>> ee)
        {
            var pgen = new FuncGenerator<TProp>(ee);

            return this.Add(pgen);
        }

        public IObjectGeneratorBuilder<TObj> CreateUsing(IObjectGenerator<TProp> generator)
        {
            var pgen = new ObjectGeneratorGenerator<TProp>(generator);

            return this.Add(pgen);
        }
    }
}