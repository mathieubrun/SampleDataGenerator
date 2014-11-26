using System;
using System.Linq.Expressions;
using SampleDataGenerator.Generators;

namespace SampleDataGenerator.Builders
{
    public class StringPropertyGeneratorBuilder<TObj> : PropertyGeneratorBuilder<TObj, string>, IStringPropertyGeneratorBuilder<TObj>
    {
        private readonly Random rnd = new Random();

        public StringPropertyGeneratorBuilder(ObjectGeneratorBuilder<TObj> from, Expression<Func<TObj, string>> expr)
            : base(from, expr)
        {
        }

        public IObjectGeneratorBuilder<TObj> LoremIpsum(int sentences)
        {
            var pgen = new StringGenerator(StaticData.LoremIpsum, sentences);

            return this.Add(pgen);
        }
    }
}