namespace SampleDataGenerator
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Property generator
    /// </summary>
    /// <typeparam name="TObj">Object type</typeparam>
    public abstract class PropertyGenerator<TObj>
    {
        protected ObjectGenerator<TObj> from;

        protected PropertyGenerator(ObjectGenerator<TObj> source)
        {
            from = source;
        }

        internal abstract void SetValue(TObj o);
    }

    public class PropertyGenerator<TObj, TProp> : PropertyGenerator<TObj>
    {
        private readonly Action<TObj, TProp> action;
        protected Func<TProp> getVal;
        private readonly Random rnd = new Random();

        public PropertyGenerator(ObjectGenerator<TObj> source, Expression<Func<TObj, TProp>> expr)
            : base(source)
        {
            var member = expr.Body;
            var param = Expression.Parameter(typeof(TProp), "value");
            var set = Expression.Lambda<Action<TObj, TProp>>(Expression.Assign(member, param), expr.Parameters[0], param);

            action = set.Compile();
        }

        public ObjectGenerator<TObj> ChooseFrom(params TProp[] list)
        {
            var enumerator = list.Loop().GetEnumerator();

            getVal = () => { enumerator.MoveNext(); return enumerator.Current; };

            return from;
        }

        public ObjectGenerator<TObj> ChooseRandomlyFrom(params TProp[] list)
        {
            getVal = () => list.Random();

            return from;
        }

        public ObjectGenerator<TObj> CreateUsing(Expression<Func<TProp>> expr)
        {
            getVal = expr.Compile();

            return from;
        }

        internal override void SetValue(TObj o)
        {
            action(o, getVal());
        }
    }
}
