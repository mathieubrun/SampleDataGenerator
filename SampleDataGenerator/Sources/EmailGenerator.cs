using System.Linq;

namespace SampleDataGenerator.Sources
{
    public class EmailGenerator : IElementGenerator<string>
    {
        public string Generate()
        {
            var firstName = new ArrayRandomizer<string>(StaticData.FirstNames);
            var domain = new ArrayRandomizer<string>(StaticData.Domains);

            return string.Format("{0}@{1}", firstName.Generate(1).FirstOrDefault(), domain.Generate(1).FirstOrDefault());
        }
    }
}