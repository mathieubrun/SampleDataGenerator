namespace SampleDataGenerator
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class PropertyGenerator<TObj, TProp> : PropertyGenerator<TObj>
    {
        private readonly Action<TObj, TProp> action;
        private readonly Random rnd = new Random();

        public PropertyGenerator(ObjectGenerator<TObj> source, Expression<Func<TObj, TProp>> expr)
            : base(source)
        {
            var member = expr.Body;
            var param = Expression.Parameter(typeof(TProp), "value");
            var set = Expression.Lambda<Action<TObj, TProp>>(Expression.Assign(member, param), expr.Parameters[0], param);

            this.action = set.Compile();
        }

        protected Func<TProp> GetVal { get; set; }

        public ObjectGenerator<TObj> ChooseFrom(params TProp[] list)
        {
            var enumerator = list.Loop().GetEnumerator();

            this.GetVal = () => { enumerator.MoveNext(); return enumerator.Current; };

            return this.From;
        }

        public ObjectGenerator<TObj> ChooseRandomlyFrom(params TProp[] list)
        {
            this.GetVal = () => list.Random();

            return this.From;
        }

        public ObjectGenerator<TObj> CreateUsing(Expression<Func<TProp>> expr)
        {
            this.GetVal = expr.Compile();

            return this.From;
        }

        public ObjectGenerator<TObj> CreateUsing(ObjectGenerator<TProp> generator)
        {
            this.GetVal = () => generator.Generate(1).First();

            return this.From;
        }

        internal override void SetValue(TObj o)
        {
            this.action(o, this.GetVal());
        }
    }
}
