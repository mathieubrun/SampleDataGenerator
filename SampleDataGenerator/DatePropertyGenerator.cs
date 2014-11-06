namespace SampleDataGenerator
{
    using System;
    using System.Linq.Expressions;

    public class DatePropertyGenerator<TObj> : PropertyGenerator<TObj, DateTime>
    {
        private readonly Random rnd = new Random();

        public DatePropertyGenerator(ObjectGenerator<TObj> source, Expression<Func<TObj, DateTime>> expr)
            : base(source, expr)
        {
        }

        public ObjectGenerator<TObj> Range(DateTime start, DateTime end)
        {
            this.GetVal = () => new DateTime(this.LongRandom(start.Ticks, end.Ticks, this.rnd));

            return this.From;
        }

        private long LongRandom(long min, long max, Random rand)
        {
            if (min == max)
            {
                return min;
            }

            byte[] buf = new byte[8];
            rand.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return Math.Abs(longRand % (max - min)) + min;
        }
    }
}
