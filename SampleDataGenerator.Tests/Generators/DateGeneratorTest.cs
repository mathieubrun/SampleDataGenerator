using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleDataGenerator.Generators;

namespace SampleDataGenerator.Tests.Generators
{
    [TestClass]
    public class DateGeneratorTest
    {
        [TestMethod]
        public void GetValue_returns_date_in_correct_range()
        {
            // arrange
            var start = DateTime.Now;
            var end = DateTime.Now.AddHours(1);

            var generator = new DateGenerator(start, end);

            // act
            var generated = generator.Get();

            // assert
            Assert.IsTrue(generated > start);
            Assert.IsTrue(generated < end);
        }
    }
}