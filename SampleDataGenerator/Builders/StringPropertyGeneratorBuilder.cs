using System;
using System.Linq.Expressions;
using SampleDataGenerator.Generators;
using SampleDataGenerator.Sources;

namespace SampleDataGenerator.Builders
{
    public class StringPropertyGeneratorBuilder<TObj> : PropertyGeneratorBuilder<TObj, string>, IStringPropertyGeneratorBuilder<TObj>
    {
        public StringPropertyGeneratorBuilder(ObjectGeneratorBuilder<TObj> from, Expression<Func<TObj, string>> expr)
            : base(from, expr)
        {
        }

        public IObjectGeneratorBuilder<TObj> LoremIpsum(int sentences)
        {
            var pgen = new JoinedStringGenerator(new RandomSource<string>(StaticData.LoremIpsum), sentences, " ");

            return this.Add(pgen);
        }

        public IObjectGeneratorBuilder<TObj> PhoneNumber(string pattern)
        {
            var pgen = new SourceGenerator<string>(new PhoneNumberSource(pattern));

            return this.Add(pgen);
        }
    }
}