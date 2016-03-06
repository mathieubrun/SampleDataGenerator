using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleDataGenerator.Sources;

namespace SampleDataGenerator.Tests.Sources
{
    [TestClass]
    public class PhoneNumberGeneratorTest
    {
        [TestMethod]
        public void PhoneNumberGenerator_Generate_must_generate_correct_number_of_items()
        {
            // arrange
            var count = 4;
            var generator = new PhoneNumberGenerator("33-000-000");

            // act
            var result = generator.Generate(count);

            // assert
            Assert.AreEqual(count, result.Count());
        }
    }
}