using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleDataGenerator.Generators;

namespace SampleDataGenerator.Tests.Generators
{
    [TestClass]
    public class RandomGeneratorTest
    {
        [TestMethod]
        public void Loop_must_expand_list_if_needed()
        {
            // arrange
            var count = 4;
            var range = Enumerable.Range(0, 2).ToArray();
            var generator = new RandomGenerator<int>(range);

            // act
            var result = Enumerable.Range(0, count).Select(x => generator.Get());

            // assert
            Assert.AreEqual(count, result.Count());
        }
    }
}