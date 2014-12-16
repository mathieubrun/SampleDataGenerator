using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SampleDataGenerator.Generators;

namespace SampleDataGenerator.Tests.Generators
{
    [TestClass]
    public class ObjectGeneratorGeneratorTest
    {
        [TestMethod]
        public void Generator_passed_as_argument_is_called()
        {
            // arrange
            var expected = new object();
            var mock = Mock.Of<IObjectGenerator<object>>();
            Mock.Get(mock).Setup(x => x.Generate()).Returns(expected);

            var generator = new ObjectGeneratorGenerator<object>(mock);

            // act
            var generated = generator.Generate();

            // assert
            Assert.AreSame(expected, generated);
            Mock.Get(mock).Verify(x => x.Generate(), Times.Once());
        }
    }
}