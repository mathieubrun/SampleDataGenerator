﻿namespace SampleDataGenerator.Tests.Builders
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using SampleDataGenerator.Builders;

    [TestClass]
    public class PropertyGeneratorBuildersTest
    {
        [TestMethod]
        public void PropertyGeneratorBuilder_Must_return_correct_builder()
        {
            // arrange
            var objectBuilder = new ObjectGeneratorBuilder<Person>();

            var sut = new PropertyGeneratorBuilder<Person, string>(objectBuilder, x => x.FirstName);

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
            var objectBuilder = new ObjectGeneratorBuilder<Person>();

            var sut = new DatePropertyGeneratorBuilder<Person>(objectBuilder, x => x.DateOfBirth);

            // act
            var builder = sut.Range(DateTime.Now, DateTime.Now);

            // assert
            Assert.AreSame(builder, objectBuilder);
        }

        [TestMethod]
        public void ArrayPropertyGeneratorBuilder_Must_return_correct_builder()
        {
            // arrange
            var objectBuilder = new ObjectGeneratorBuilder<Person>();

            var sut = new ArrayPropertyGeneratorBuilder<Person, Person>(objectBuilder, x => x.Relatives);

            // act
            var builder = sut.CreateUsing(Mock.Of<IObjectGenerator<Person>>(), 1);

            // assert
            Assert.AreSame(builder, objectBuilder);
        }
    }
}