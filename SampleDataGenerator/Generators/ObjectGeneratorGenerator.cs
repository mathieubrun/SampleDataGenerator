using SampleDataGenerator.Sources;

namespace SampleDataGenerator.Generators
{
    public class ObjectGeneratorGenerator<TProp> : IElementGenerator<TProp>
    {
        private readonly IObjectGenerator<TProp> generator;

        public ObjectGeneratorGenerator(IObjectGenerator<TProp> generator)
        {
            this.generator = generator;
        }

        public TProp Generate()
        {
            return this.generator.Generate();
        }
    }
}