using System;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SampleDataGenerator.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void Create_simple_object()
        {
            // arrange
            var firstNames = StaticData.FirstNames;
            var lastNames = StaticData.LastNames;

            var generator = Generator.For<TestObject>();

            generator
                .For(x => x.DateTimeProperty)
                    .Range(DateTime.Now.AddYears(-20), DateTime.Now)
                .For(x => x.StringProperty1)
                    .ChooseFrom(StaticData.FirstNames)
                .For(x => x.StringProperty2)
                    .ChooseFrom(StaticData.LastNames)
                .For(x => x.StringProperty3)
                    .PhoneNumber(StaticData.PhoneNumbersPatterns.France)
                .For(x => x.StringProperty4)
                    .LoremIpsum(2)
                .For(x => x.GuidProperty)
                    .CreateUsing(() => Guid.NewGuid());

            // act
            var data = generator.Generate();

            // assert
            Assert.IsTrue(firstNames.Contains(data.StringProperty1));
            Assert.IsTrue(lastNames.Contains(data.StringProperty2));
            Assert.IsFalse(data.GuidProperty == default(Guid));
        }
    }
}