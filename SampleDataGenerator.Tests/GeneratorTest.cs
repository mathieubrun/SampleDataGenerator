namespace SampleDataGenerator.Tests
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GeneratorTest
    {
        [TestMethod]
        public void SimpleObject()
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

        [TestMethod]
        public void NestedObjects()
        {
            // arrange
            var count = 50;

            var countries = StaticData.Countries;
            var firstNames = StaticData.FirstNames;
            var lastNames = StaticData.LastNames;

            var adressGenerator =
                Generator
                    .For<Address>()
                    .For(x => x.Country)
                        .ChooseRandomlyFrom(StaticData.Countries);

            var clientGenerator =
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
                    .For(x => x.Address)
                        .CreateUsing(adressGenerator)
                    .For(x => x.Addresses)
                        .CreateUsing(adressGenerator, 3)
                    .For(x => x.Id)
                        .CreateUsing(() => Guid.NewGuid());

            // act
            var data = clientGenerator.Generate(50).ToList();

            // assert
            foreach (var d in data)
            {
                Assert.IsTrue(countries.Contains(d.Address.Country));
                Assert.IsTrue(firstNames.Contains(d.FirstName));
                Assert.IsTrue(lastNames.Contains(d.LastName));
                Assert.IsFalse(d.Id == default(Guid));
            }

            Assert.AreEqual(count, data.Count);
        }
    }
}
