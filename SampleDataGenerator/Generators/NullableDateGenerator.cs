﻿using System;

namespace SampleDataGenerator.Generators
{
    public class NullableDateGenerator : IPropertyGenerator<DateTime?>
    {
        private readonly Random rnd = new Random();
        private readonly DateTime startDate;
        private readonly DateTime endDate;

        public NullableDateGenerator(DateTime startDate, DateTime endDate)
        {
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public DateTime? Get()
        {
            // from : http://stackoverflow.com/a/1483677/971
            var timeSpan = endDate - startDate;

            var newSpan = new TimeSpan(0, this.rnd.Next(0, (int)timeSpan.TotalMinutes), 0);

            return startDate + newSpan;
        }
    }
}