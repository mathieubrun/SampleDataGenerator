using System;
using System.IO;

namespace SampleDataGenerator
{
    public static class StaticData
    {
        private static Lazy<string[]> firstNames = new Lazy<string[]>(() => ReadData("FirstNames"));

        private static Lazy<string[]> lastNames = new Lazy<string[]>(() => ReadData("LastNames"));

        private static Lazy<string[]> countries = new Lazy<string[]>(() => ReadData("Countries"));

        private static Lazy<string[]> companies = new Lazy<string[]>(() => ReadData("Companies"));

        private static Lazy<string[]> loremIpsum = new Lazy<string[]>(() => ReadData("LoremIpsum"));

        private static Lazy<string[]> domains = new Lazy<string[]>(() => ReadData("Domains"));

        /// <summary>
        /// Gets first names
        /// </summary>
        /// <remarks>
        /// From : https://github.com/hadley/data-baby-names/blob/master/baby-names.csv
        /// </remarks>
        public static string[] FirstNames
        {
            get
            {
                return firstNames.Value;
            }
        }

        /// <summary>
        /// Gets last names
        /// </summary>
        /// <remarks>
        /// From http://names.mongabay.com/most_common_surnames.htm
        /// </remarks>
        public static string[] LastNames
        {
            get
            {
                return lastNames.Value;
            }
        }

        /// <summary>
        /// Gets company names
        /// </summary>
        /// <remarks>
        /// From http://brendoman.com/media/users/dan/finctional_companies.txt
        /// </remarks>
        public static string[] Companies
        {
            get
            {
                return companies.Value;
            }
        }

        /// <summary>
        /// Gets countries
        /// </summary>
        /// <remarks>
        /// From http://www.state.gov/misc/list/
        /// </remarks>
        public static string[] Countries
        {
            get
            {
                return countries.Value;
            }
        }

        /// <summary>
        /// Gets lorem ipsum lines
        /// </summary>
        /// <remarks>
        /// From http://en.wikipedia.org/wiki/Lorem_ipsum#Latin_source
        /// </remarks>
        public static string[] LoremIpsum
        {
            get
            {
                return loremIpsum.Value;
            }
        }

        /// <summary>
        /// Gets domain names
        /// </summary>
        /// <remarks>
        /// From http://www.alexa.com/topsites
        /// </remarks>
        public static string[] Domains
        {
            get
            {
                return domains.Value;
            }
        }

        private static string[] ReadData(string resourceName)
        {
            var str = typeof(StaticData).Assembly.GetManifestResourceStream(string.Format("SampleDataGenerator.Data.{0}.txt", resourceName));
            using (var rdr = new StreamReader(str))
            {
                return rdr.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public static class PhoneNumbersPatterns
        {
            public const string France = "+33X XX XX XX XX";
        }
    }
}