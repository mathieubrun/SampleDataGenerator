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
            var count = 50;

            var firstNames = StaticData.FirstNames;
            var lastNames = StaticData.LastNames;

            var personGenerator = Generator.For<TestObject>();

            personGenerator
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
            var data = personGenerator.Generate(50).ToList();

            // assert
            foreach (var d in data)
            {
                Assert.IsTrue(firstNames.Contains(d.StringProperty1));
                Assert.IsTrue(lastNames.Contains(d.StringProperty2));
                Assert.IsFalse(d.GuidProperty == default(Guid));
            }

            Assert.AreEqual(count, data.Count);
        }
    }
}