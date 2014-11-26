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

            var personGenerator = Generator.For<Person>();

            personGenerator
                .For(x => x.DateOfBirth)
                    .Range(DateTime.Now.AddYears(-20), DateTime.Now)
                .For(x => x.FirstName)
                    .ChooseFrom(StaticData.FirstNames)
                .For(x => x.LastName)
                    .ChooseFrom(StaticData.LastNames)
                .For(x => x.Phone)
                    .PhoneNumber("00-00000-00")
                .For(x => x.Description)
                    .LoremIpsum(2)
                .For(x => x.Id)
                    .CreateUsing(() => Guid.NewGuid());

            // act
            var data = personGenerator.Generate(50).ToList();

            // assert
            foreach (var d in data)
            {
                Assert.IsTrue(firstNames.Contains(d.FirstName));
                Assert.IsTrue(lastNames.Contains(d.LastName));
                Assert.IsFalse(d.Id == default(Guid));
            }

            Assert.AreEqual(count, data.Count);
        }
    }
}