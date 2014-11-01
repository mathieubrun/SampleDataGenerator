namespace SampleDataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    
    /// <summary>
    /// Object generator
    /// </summary>
    /// <typeparam name="TObj">Object type</typeparam>
    public class ObjectGenerator<TObj>
    {
        private readonly List<PropertyGenerator<TObj>> propertyGenerators = new List<PropertyGenerator<TObj>>();

        /// <summary>
        /// Defines the property setter that will be used
        /// </summary>
        /// <typeparam name="TProp">Property type</typeparam>
        /// <param name="propertyExpression">The setter</param>
        /// <returns></returns>
        public PropertyGenerator<TObj, TProp> For<TProp>(Expression<Func<TObj, TProp>> propertyExpression)
        {
            var p = new PropertyGenerator<TObj, TProp>(this, propertyExpression);
            propertyGenerators.Add(p);
            return p;
        }

        /// <summary>
        /// Defines the property setter that will be used
        /// </summary>
        /// <typeparam name="TProp">Property type</typeparam>
        /// <param name="propertyExpression">The setter</param>
        /// <returns></returns>
        public DatePropertyGenerator<TObj> For(Expression<Func<TObj, DateTime>> propertyExpression)
        {
            var p = new DatePropertyGenerator<TObj>(this, propertyExpression);
            propertyGenerators.Add(p);
            return p;
        }

        /// <summary>
        /// Generates an enumeration of TObj
        /// </summary>
        /// <param name="count">How many TObj will get created</param>
        /// <returns></returns>
        public IEnumerable<TObj> Generate(int count)
        {
            return Enumerable.Range(0, count)
                .Select(x => Create());
        }

        private TObj Create()
        {
            var o = Activator.CreateInstance<TObj>();

            propertyGenerators.ForEach(x => x.SetValue(o));

            return o;
        }
    }
}
