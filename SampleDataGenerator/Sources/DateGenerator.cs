using System;
using System.Collections.Generic;

namespace SampleDataGenerator.Sources
{
    public class DateGenerator : IElementGenerator<DateTime>
    {
        private readonly Random rnd = new Random();
        private readonly DateTime startDate;
        private readonly DateTime endDate;

        public DateGenerator(DateTime startDate, DateTime endDate)
        {
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public DateTime Generate()
        {
            // from : http://stackoverflow.com/a/1483677/971
            var timeSpan = endDate - startDate;

            var newSpan = new TimeSpan(0, this.rnd.Next(0, (int)timeSpan.TotalMinutes), 0);

            return startDate + newSpan;
        }

        public IEnumerable<DateTime> Generate(int count)
        {
            while (count-- > 0)
            {
                yield return Generate();
            }
        }
    }
}