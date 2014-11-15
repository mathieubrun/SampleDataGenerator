namespace SampleDataGenerator
{
    using SampleDataGenerator.Builders;

    /// <summary>
    /// Data generator entry point
    /// </summary>
    public class Generator
    {
        /// <summary>
        /// Creates an object generator for the type you want to generate instances of.
        /// </summary>
        /// <typeparam name="TObj">Object type to generate</typeparam>
        /// <returns>An ObjectGenerator instance for requested type</returns>
        public static ObjectGeneratorBuilder<TObj> For<TObj>()
        {
            return new ObjectGeneratorBuilder<TObj>();
        }
    }
}