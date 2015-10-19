using System;
using System.Linq;
using System.Linq.Expressions;
using SampleDataGenerator.Generators;
using SampleDataGenerator.Sources;

namespace SampleDataGenerator.Builders
{
    public class PropertyGeneratorBuilder<TObj, TProp> : PropertyGeneratorBuilderBase<TObj, TProp>, IPropertyGeneratorBuilder<TObj, TProp>
    {
        public PropertyGeneratorBuilder(ObjectGeneratorBuilder<TObj> from, Expression<Func<TObj, TProp>> expression)
            : base(from, expression)
        {
        }

        protected PropertyGeneratorBuilder(ObjectGeneratorBuilder<TObj> from, Expression<Action<TObj, TProp>> expression)
            : base(from, expression)
        {
        }

        public IObjectGeneratorBuilder<TObj> ChooseFrom(params TProp[] list)
        {
            var gen = new ArraySequencer<TProp>(list);

            var pgen = new FuncGenerator<TProp>(() => gen.Generate(1).FirstOrDefault());

            return this.Add(pgen);
        }

        public IObjectGeneratorBuilder<TObj> ChooseRandomlyFrom(params TProp[] list)
        {
            var gen = new ArrayRandomizer<TProp>(list);

            var pgen = new FuncGenerator<TProp>(() => gen.Generate(1).FirstOrDefault());

            return this.Add(pgen);
        }

        public IObjectGeneratorBuilder<TObj> CreateUsing(Expression<Func<TProp>> expression)
        {
            var pgen = new FuncGenerator<TProp>(expression);

            return this.Add(pgen);
        }

        public IObjectGeneratorBuilder<TObj> CreateUsing(IObjectGenerator<TProp> generator)
        {
            var pgen = new ObjectGeneratorGenerator<TProp>(generator);

            return this.Add(pgen);
        }
    }
}