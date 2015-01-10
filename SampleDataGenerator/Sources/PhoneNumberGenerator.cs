using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleDataGenerator.Sources
{
    public class PhoneNumberGenerator : IElementGenerator<string>
    {
        private readonly string pattern;
        private readonly Random rnd = new Random();

        public PhoneNumberGenerator(string pattern)
        {
            this.pattern = pattern;
        }

        public string Generate()
        {
            var result = new StringBuilder();

            foreach (var c in pattern)
            {
                switch (c)
                {
                    case 'X':
                        result.Append(rnd.Next(0, 10));
                        break;
                    default:
                        result.Append(c);
                        break;
                }
            }

            return result.ToString();
        }

        public IEnumerable<string> Generate(int count)
        {
            while (count-- > 0)
            {
                yield return Generate();
            }
        }
    }
}