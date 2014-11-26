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

        /// <summary>
        /// First names
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
        /// Company names
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
        /// Countries
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

        private static string[] ReadData(string resourceName)
        {
            using (var str = typeof(StaticData).Assembly.GetManifestResourceStream(string.Format("SampleDataGenerator.Data.{0}.txt", resourceName)))
            {
                using (var rdr = new StreamReader(str))
                {
                    return rdr.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                }
            }
        }
    }
}