namespace SampleDataGenerator.Tests.Generators
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SampleDataGenerator.Generators;

    [TestClass]
    public class FuncGeneratorTest
    {
        [TestMethod]
        public void Function_passed_as_argument_is_called()
        {
            // arrange
            var expected = new object();
            var generator = new FuncGenerator<object>(() => expected);

            // act
            var generated = generator.Get();

            // assert
            Assert.AreSame(expected, generated);
        }
    }
}