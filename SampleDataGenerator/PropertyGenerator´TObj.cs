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
        protected PropertyGenerator(ObjectGenerator<TObj> source)
        {
            this.From = source;
        }

        protected ObjectGenerator<TObj> From { get; set; }

        internal abstract void SetValue(TObj o);
    }
}
