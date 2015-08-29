using System.Linq;
using System.Text.RegularExpressions;

namespace SampleDataGenerator.Sources
{
    public class EmailGenerator : IElementGenerator<string>
    {
        public string Generate()
        {
            var firstName = new ArrayRandomizer<string>(StaticData.FirstNames);
            var domain = new DomainGenerator();

            return string.Format("{0}@{1}", firstName.Generate(1).FirstOrDefault(), domain.Generate());
        }
    }
}