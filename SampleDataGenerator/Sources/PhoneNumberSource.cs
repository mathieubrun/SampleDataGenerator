using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleDataGenerator.Sources
{
    public class PhoneNumberSource : ISource<string>
    {
        private readonly string pattern;
        private readonly Random rnd = new Random();

        public PhoneNumberSource(string pattern)
        {
            this.pattern = pattern;
        }

        public string Get()
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

        public IEnumerable<string> Get(int count)
        {
            while (count-- > 0)
            {
                yield return Get();
            }
        }
    }
}