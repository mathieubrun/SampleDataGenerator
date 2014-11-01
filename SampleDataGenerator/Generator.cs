namespace SampleDataGenerator
{
    /// <summary>
    /// Data generator entry point
    /// </summary>
    public class Generator
    {
        /// <summary>
        /// Specifies the type to generate
        /// </summary>
        /// <typeparam name="TObj">Object type</typeparam>
        /// <returns></returns>
        public static ObjectGenerator<TObj> For<TObj>()
        {
            return new ObjectGenerator<TObj>();
        }
    }
}
