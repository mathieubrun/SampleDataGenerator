using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SampleDataGenerator.Sources;

namespace SampleDataGenerator.Generators
{
    /// <summary>
    /// Object generator
    /// </summary>
    /// <typeparam name="TObj">Object type</typeparam>
    public class ObjectGenerator<TObj> : IObjectGenerator<TObj>
    {
        private List<IPropertyAssigner<TObj>> assigners = new List<IPropertyAssigner<TObj>>();

        private interface IPropertyAssigner<TObject>
        {
            void SetValueOnTarget(TObject target);
        }

        public TObj Generate()
        {
            var o = Activator.CreateInstance<TObj>();

            this.assigners.ForEach(x => x.SetValueOnTarget(o));

            return o;
        }

        public IEnumerable<TObj> Generate(int count)
        {
            return Enumerable.Range(0, count)
                .Select(x => this.Generate());
        }

        internal void Add<TProp>(IElementGenerator<TProp> build, Expression<Action<TObj, TProp>> expr)
        {
            this.assigners.Add(new Assigner<TProp>(expr, build));
        }

        internal void Add<TProp>(IDependentElementGenerator<TObj, TProp> build, Expression<Action<TObj, TProp>> expr)
        {
            this.assigners.Add(new DependantAssigner<TProp>(expr, build));
        }

        private class Assigner<TProp> : IPropertyAssigner<TObj>
        {
            private readonly Action<TObj, TProp> action;
            private readonly IElementGenerator<TProp> generator;

            public Assigner(Expression<Action<TObj, TProp>> expr, IElementGenerator<TProp> generator)
            {
                this.action = expr.Compile();
                this.generator = generator;
            }

            public void SetValueOnTarget(TObj target)
            {
                this.action(target, this.generator.Generate());
            }
        }

        private class DependantAssigner<TProp> : IPropertyAssigner<TObj>
        {
            private readonly Action<TObj, TProp> action;
            private readonly IDependentElementGenerator<TObj, TProp> generator;

            public DependantAssigner(Expression<Action<TObj, TProp>> expr, IDependentElementGenerator<TObj, TProp> generator)
            {
                this.action = expr.Compile();
                this.generator = generator;
            }

            public void SetValueOnTarget(TObj target)
            {
                this.action(target, this.generator.Generate(target));
            }
        }
    }
}