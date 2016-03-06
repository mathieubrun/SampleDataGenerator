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

            var sut = Generator.For<TestObject>()
                .For(x => x.DateTimeProperty)
                    .Range(minDate, maxDate)
                .For(x => x.StringProperty1)
                    .ChooseFrom(firstNames)
                .For(x => x.StringProperty2)
                    .PhoneNumber(StaticData.PhoneNumbersPatterns.France)
                .For(x => x.StringProperty3)
                    .LoremIpsum(2)
                .For(x => x.GuidProperty)
                    .CreateUsing(() => Guid.NewGuid());

            // act
            var data = sut.Generate();

            // assert
            Assert.IsTrue(data.DateTimeProperty >= minDate);
            Assert.IsTrue(data.DateTimeProperty <= maxDate);
            Assert.IsTrue(firstNames.Contains(data.StringProperty1));
            Assert.IsFalse(data.GuidProperty == default(Guid));
        }

        [TestMethod]
        public void Nullable_properties()
        {
            // arrange
            var sut = Generator.For<TestObject>()
                .For(x => x.DateTimeProperty)
                    .Range(DateTime.Now.AddYears(-20), DateTime.Now)
                .For(x => x.GuidProperty)
                    .CreateUsing(() => Guid.NewGuid());

            // act
            var data = sut.Generate();

            // assert
            Assert.IsFalse(data.GuidProperty == default(Guid?));
            Assert.IsFalse(data.DateTimeProperty == default(DateTime?));
        }

        [TestMethod]
        public void Dependant_properties()
        {
            // arrange
            var firstName = "John";
            var lastName = "Doe";

            var sut = Generator.For<TestObject>()
                .For(x => x.StringProperty1)
                    .CreateUsing(() => firstName)
                .For(x => x.StringProperty2)
                    .CreateUsing(() => lastName)
                .For(x => x.StringProperty3)
                    .Email(x => x.StringProperty1, x => x.StringProperty2);

            // act
            var data = sut.Generate();

            // assert
            Assert.AreEqual(firstName, data.StringProperty1);
            Assert.AreEqual(lastName, data.StringProperty2);
            Assert.AreEqual(string.Format("{0}@{1}.com", firstName, lastName), data.StringProperty3);
        }

        [TestMethod]
        public void Dependant_properties_unsorted()
        {
            // arrange
            var firstName = "John";
            var lastName = "Doe";

            var sut = Generator.For<TestObject>()
                .For(x => x.StringProperty3)
                    .Email(x => x.StringProperty1, x => x.StringProperty2)
                .For(x => x.StringProperty1)
                    .CreateUsing(() => firstName)
                .For(x => x.StringProperty2)
                    .CreateUsing(() => lastName);

            // act
            var data = sut.Generate();

            // assert
            Assert.AreEqual(firstName, data.StringProperty1);
            Assert.AreEqual(lastName, data.StringProperty2);
            Assert.AreEqual("@.com", data.StringProperty3);
        }

        [TestMethod]
        public void Website_and_email()
        {
            // arrange
            var firstName = "John";
            var company = "Smart Company";

            var sut = Generator.For<TestObject>()
                .For(x => x.StringProperty1)
                    .CreateUsing(() => firstName)
                .For(x => x.StringProperty2)
                    .CreateUsing(() => company)
                .For(x => x.StringProperty3)
                    .Email(x => x.StringProperty1, x => x.StringProperty2)
                .For(x => x.StringProperty4)
                    .Website(x => x.StringProperty2);

            // act
            var data = sut.Generate();

            // assert
            Assert.AreEqual(firstName, data.StringProperty1);
            Assert.AreEqual("John@SmartCompany.com", data.StringProperty3);
            Assert.AreEqual("http://www.SmartCompany.com", data.StringProperty4);
        }
    }
}