using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleDataGenerator.Sources;

namespace SampleDataGenerator.Tests.Generators
{
    [TestClass]
    public class DateGeneratorTest
    {
        [TestMethod]
        public void DateGenerator_Generate_returns_date_in_correct_range_for_same_date()
        {
            // arrange
            var start = DateTime.Now;
            var end = DateTime.Now;

            var generator = new DateGenerator(start, end);

            // act
            var generated = generator.Generate();

            // assert
            Assert.AreEqual(generated, start);
            Assert.AreEqual(generated, end);
        }

        [TestMethod]
        public void DateGenerator_Generate_returns_date_in_correct_range()
        {
            // arrange
            var start = DateTime.Now;
            var end = DateTime.Now.AddMinutes(1);

            var generator = new DateGenerator(start, end);

            // act
            var generated = generator.Generate();

            // assert
            Assert.IsTrue(generated >= start);
            Assert.IsTrue(generated < end);
        }
    }
}