namespace SampleDataGenerator.Builders
{
    using SampleDataGenerator.Generators;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class DatePropertyGeneratorBuilder<TObj> : PropertyGeneratorBuilderBase<TObj, DateTime>
    {
        private readonly Random rnd = new Random();

        public DatePropertyGeneratorBuilder(ObjectGeneratorBuilder<TObj> from, Expression<Func<TObj, DateTime>> expr)
            : base(from, expr)
        {
        }

        public ObjectGeneratorBuilder<TObj> Range(DateTime start, DateTime end)
        {
            var pgen = new FuncGenerator<DateTime>(() => new DateTime(this.LongRandom(start.Ticks, end.Ticks, this.rnd)));

            return this.Add(pgen);
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
