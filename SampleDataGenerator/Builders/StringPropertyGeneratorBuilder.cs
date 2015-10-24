using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using SampleDataGenerator.Generators;
using SampleDataGenerator.Sources;

namespace SampleDataGenerator.Builders
{
    public class StringPropertyGeneratorBuilder<TObj> : PropertyGeneratorBuilder<TObj, string>, IStringPropertyGeneratorBuilder<TObj>
    {
        private readonly Func<string, string> uppercase = x => Regex.Replace(CultureInfo.InvariantCulture.TextInfo.ToTitleCase(x ?? ""), "[^a-zA-Z0-9]+", "");

        public StringPropertyGeneratorBuilder(ObjectGeneratorBuilder<TObj> from, Expression<Func<TObj, string>> expression)
            : base(from, expression)
        {
        }

        public IObjectGeneratorBuilder<TObj> LoremIpsum(int sentences)
        {
            var pgen = new JoinedStringSource(new ArrayRandomizer<string>(StaticData.LoremIpsum), sentences, " ");

            return this.Add(pgen);
        }

        public IObjectGeneratorBuilder<TObj> PhoneNumber(string pattern)
        {
            var gen = new PhoneNumberGenerator(pattern);

            var pgen = new FuncGenerator<string>(() => gen.Generate());

            return this.Add(pgen);
        }

        public IObjectGeneratorBuilder<TObj> Email(params Expression<Func<TObj, string>>[] sources)
        {
            var tokens = GetTokens(sources);

            tokens.Insert(tokens.Count - 1, "@");

            var format = string.Join("", tokens) + ".com";

            var pgen = new StringFormatGenerator<TObj>(format, uppercase, sources);

            return this.Add(pgen);
        }

        public IObjectGeneratorBuilder<TObj> Website(params Expression<Func<TObj, string>>[] sources)
        {
            var tokens = GetTokens(sources);

            var format = "http://www." + string.Join("", tokens) + ".com";

            var pgen = new StringFormatGenerator<TObj>(format, uppercase, sources);

            return this.Add(pgen);
        }

        private static List<string> GetTokens(Expression<Func<TObj, string>>[] sources)
        {
            return Enumerable.Range(0, sources.Length).Select(x => string.Format("{{{0}}}", x)).ToList();
        }
    }
}