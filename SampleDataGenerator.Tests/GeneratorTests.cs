using System;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SampleDataGenerator.Tests
{
    [TestClass]
    public class GeneratorTests
    {
        [TestMethod]
        public void Create_simple_object()
        {
            // arrange
            var minDate = DateTime.Now.AddYears(-20);
            var maxDate = DateTime.Now;
            var firstNames = StaticData.FirstNames;

            var sut = Generator.For<Person>()
                .For(x => x.DateOfBirth)
                    .Range(minDate, maxDate)
                .For(x => x.FirstName)
                    .ChooseFrom(firstNames)
                .For(x => x.PhoneNumber)
                    .PhoneNumber(StaticData.PhoneNumbersPatterns.France)
                .For(x => x.Bio)
                    .LoremIpsum(2)
                .For(x => x.Identifier)
                    .CreateUsing(() => Guid.NewGuid());

            // act
            var data = sut.Generate();

            // assert
            Assert.IsTrue(data.DateOfBirth >= minDate);
            Assert.IsTrue(data.DateOfBirth <= maxDate);
            Assert.IsTrue(firstNames.Contains(data.FirstName));
            Assert.IsFalse(data.Identifier == default(Guid));
        }

        [TestMethod]
        public void Nullable_properties()
        {
            // arrange
            var sut = Generator.For<Person>()
                .For(x => x.WeddingDate)
                    .Range(DateTime.Now.AddYears(-20), DateTime.Now)
                .For(x => x.ForeignKeyIdentifier)
                    .CreateUsing(() => Guid.NewGuid());

            // act
            var data = sut.Generate();

            // assert
            Assert.IsFalse(data.ForeignKeyIdentifier == default(Guid?));
            Assert.IsFalse(data.WeddingDate == default(DateTime?));
        }

        [TestMethod]
        public void Dependant_properties()
        {
            // arrange
            var firstName = "John";
            var lastName = "Doe";

            var sut = Generator.For<Person>()
                .For(x => x.FirstName)
                    .CreateUsing(() => firstName)
                .For(x => x.LastName)
                    .CreateUsing(() => lastName)
                .For(x => x.Email)
                    .Email(x => x.FirstName, x => x.LastName);

            // act
            var data = sut.Generate();

            // assert
            Assert.AreEqual(firstName, data.FirstName);
            Assert.AreEqual(lastName, data.LastName);
            Assert.AreEqual(string.Format("{0}@{1}.com", firstName, lastName), data.Email);
        }

        [TestMethod]
        public void Dependant_properties_unsorted()
        {
            // arrange
            var firstName = "John";
            var lastName = "Doe";

            var sut = Generator.For<Person>()
                .For(x => x.Email)
                    .Email(x => x.FirstName, x => x.LastName)
                .For(x => x.FirstName)
                    .CreateUsing(() => firstName)
                .For(x => x.LastName)
                    .CreateUsing(() => lastName);

            // act
            var data = sut.Generate();

            // assert
            Assert.AreEqual(firstName, data.FirstName);
            Assert.AreEqual(lastName, data.LastName );
            Assert.AreEqual("@.com", data.Email );
        }

        [TestMethod]
        public void Website_and_email()
        {
            // arrange
            var firstName = "John";
            var company = "Smart Company";

            var sut = Generator.For<Person>()
                .For(x => x.FirstName)
                    .CreateUsing(() => firstName)
                .For(x => x.Company)
                    .CreateUsing(() => company)
                .For(x => x.Email)
                    .Email(x => x.FirstName, x => x.Company)
                .For(x => x.Website)
                    .Website(x => x.Company);

            // act
            var data = sut.Generate();

            // assert
            Assert.AreEqual(firstName, data.FirstName);
            Assert.AreEqual("John@SmartCompany.com", data.Email);
            Assert.AreEqual("http://www.SmartCompany.com", data.Website);
        }
    }
}