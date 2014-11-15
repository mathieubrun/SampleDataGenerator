﻿namespace SampleDataGenerator.Builders
{
    using SampleDataGenerator.Generators;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class DatePropertyGeneratorBuilder<TObj> : PropertyGeneratorBuilder<TObj, DateTime>
    {
        private readonly Random rnd = new Random();

        public DatePropertyGeneratorBuilder(ObjectGeneratorBuilder<TObj> from, Expression<Func<TObj, DateTime>> expr)
            : base(from, expr)
        {
        }

        public ObjectGeneratorBuilder<TObj> Range(DateTime start, DateTime end)
        {
            var pgen = new FuncGenerator<DateTime>(() => GetDate(start, end));

            return this.Add(pgen);
        }

        private DateTime GetDate(DateTime startDate, DateTime endDate)
        {
            // from : http://stackoverflow.com/a/1483677/971
            var timeSpan = endDate - startDate;

            var newSpan = new TimeSpan(0, rnd.Next(0, (int)timeSpan.TotalMinutes), 0);
            
            return startDate + newSpan;
        }
    }
}