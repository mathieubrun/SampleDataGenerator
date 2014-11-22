namespace SampleDataGenerator.Tests.Builders
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using SampleDataGenerator.Builders;

    [TestClass]
    public class ObjectGeneratorBuildersTest
    {
        [TestMethod]
        public void ObjectGeneratorBuilder_Must_return_correct_builder()
        {
            // arrange
            var sut = new ObjectGeneratorBuilder<Person>();

            // act
            var dateBuilder = sut.For(x => x.DateOfBirth);
            var propertyBuilder = sut.For(x => x.FirstName);
            var arrayBuilder = sut.For(x => x.Relatives);

            // assert
            Assert.IsInstanceOfType(dateBuilder, typeof(DatePropertyGeneratorBuilder<Person>));
            Assert.IsInstanceOfType(propertyBuilder, typeof(PropertyGeneratorBuilder<Person, string>));
            Assert.IsInstanceOfType(arrayBuilder, typeof(ArrayPropertyGeneratorBuilder<Person, Person>));
        }
    }
}