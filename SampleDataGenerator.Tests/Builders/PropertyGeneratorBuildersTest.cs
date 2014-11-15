using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleDataGenerator.Builders;
using Moq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace SampleDataGenerator.Tests.Builders
{
    [TestClass]
    public class PropertyGeneratorBuildersTest
    {
        [TestMethod]
        public void PropertyGeneratorBuilder_Must_return_correct_builder()
        {
            // arrange
            var objectBuilder = new ObjectGeneratorBuilder<Client>();

            var sut = new PropertyGeneratorBuilder<Client, string>(objectBuilder, x => x.FirstName);

            // act
            var builder1 = sut.ChooseFrom("");
            var builder2 = sut.ChooseRandomlyFrom("");
            var builder3 = sut.CreateUsing(() => "");

            // assert
            Assert.AreSame(builder1, objectBuilder);
            Assert.AreSame(builder2, objectBuilder);
            Assert.AreSame(builder3, objectBuilder);
        }

        [TestMethod]
        public void DatePropertyGeneratorBuilder_Must_return_correct_builder()
        {
            // arrange
            var objectBuilder = new ObjectGeneratorBuilder<Client>();

            var sut = new DatePropertyGeneratorBuilder<Client>(objectBuilder, x => x.DateOfBirth);

            // act
            var builder = sut.Range(DateTime.Now, DateTime.Now);

            // assert
            Assert.AreSame(builder, objectBuilder);
        }

        [TestMethod]
        public void ArrayPropertyGeneratorBuilder_Must_return_correct_builder()
        {
            // arrange
            var objectBuilder = new ObjectGeneratorBuilder<Client>();

            var sut = new ArrayPropertyGeneratorBuilder<Client, Address>(objectBuilder, x => x.Addresses);

            // act
            var builder = sut.CreateUsing(Mock.Of<IObjectGenerator<Address>>(), 1);

            // assert
            Assert.AreSame(builder, objectBuilder);
        }
    }
}
