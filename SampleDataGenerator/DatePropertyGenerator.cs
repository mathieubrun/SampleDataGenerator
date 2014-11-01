using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SampleDataGenerator
{
    public class DatePropertyGenerator<TObj> : PropertyGenerator<TObj, DateTime>
    {
        private readonly Random rnd = new Random();

        public DatePropertyGenerator(ObjectGenerator<TObj> source, Expression<Func<TObj, DateTime>> expr)
            : base(source, expr)
        {
        }

        public ObjectGenerator<TObj> Range(DateTime start, DateTime end)
        {
            getVal = () => new DateTime(LongRandom(start.Ticks, end.Ticks, rnd));

            return from;
        }

        private long LongRandom(long min, long max, Random rand)
        {
            if (min == max) return min;

            byte[] buf = new byte[8];
            rand.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return (Math.Abs(longRand % (max - min)) + min);
        }
    }
}
