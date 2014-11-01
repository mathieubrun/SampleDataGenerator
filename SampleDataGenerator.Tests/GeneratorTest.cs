using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace SampleDataGenerator.Tests
{
    public class Client
    {
        public Guid Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
    }

    [TestClass]
    public class GeneratorTest
    {
        [TestMethod]
        public void SampleData()
        {
            // arrange
            var count = 50;

            var firstNames = StaticData.FirstNames;
            var lastNames = StaticData.LastNames;

            var generator =
                Generator
                    .For<Client>()
                    .For(x => x.FirstName)
                        .ChooseFrom(StaticData.FirstNames)
                    .For(x => x.DateOfBirth)
                        .Range(DateTime.Now, DateTime.Now.AddYears(1))
                    .For(x => x.LastName)
                        .ChooseFrom(StaticData.LastNames)
                    .For(x => x.Company)
                        .ChooseFrom(StaticData.Companies)
                    .For(x => x.Id)
                        .CreateUsing(() => Guid.NewGuid());
                    

            // act
            var data = generator.Generate(50).ToList();

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
