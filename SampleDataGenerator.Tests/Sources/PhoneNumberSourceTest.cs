using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleDataGenerator.Sources;

namespace SampleDataGenerator.Tests.Sources
{
    [TestClass]
    public class PhoneNumberSourceTest
    {
        [TestMethod]
        public void Loop_must_expand_list_if_needed()
        {
            // arrange
            var count = 4;
            var generator = new PhoneNumberSource("00-000-000");

            // act
            var result = generator.Get(count);

            // assert
            Assert.AreEqual(count, result.Count());
        }
    }
}