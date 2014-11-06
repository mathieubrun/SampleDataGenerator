namespace SampleDataGenerator.Tests
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
