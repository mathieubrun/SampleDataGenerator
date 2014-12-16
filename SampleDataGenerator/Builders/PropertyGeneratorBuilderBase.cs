﻿using System;
using System.Linq.Expressions;
using SampleDataGenerator.Generators;
using SampleDataGenerator.Sources;

namespace SampleDataGenerator.Builders
{
    public class PropertyGeneratorBuilderBase<TObj, TProp>
    {
        private readonly ObjectGeneratorBuilder<TObj> builder;
        private readonly Expression<Func<TObj, TProp>> expr;

        public PropertyGeneratorBuilderBase(ObjectGeneratorBuilder<TObj> from, Expression<Func<TObj, TProp>> expr)
        {
            this.expr = expr;
            this.builder = from;
        }

        protected ObjectGeneratorBuilder<TObj> Add(IElementGenerator<TProp> build)
        {
            return this.builder.Add<TProp>(build, this.expr);
        }
    }
}