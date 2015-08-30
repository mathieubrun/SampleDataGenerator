using System.Linq;
using System.Text.RegularExpressions;

namespace SampleDataGenerator.Sources
{
    public class DomainGenerator : IElementGenerator<string>
    {
        private readonly string[] domains = new[]
        {
            ".com",
            ".net",
            ".org",
            ".biz"
        };    

        public string Generate()
        {
            var company = new ArrayRandomizer<string>(StaticData.Companies);
            var domain = new ArrayRandomizer<string>(domains);

            return Regex.Replace(company.Generate(1).FirstOrDefault().ToLower(), "[^a-z]+", "-").Trim('-') + domain.Generate(1).FirstOrDefault();
        }
    }
}