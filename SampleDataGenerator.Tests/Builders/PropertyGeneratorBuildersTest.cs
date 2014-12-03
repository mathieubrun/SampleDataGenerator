using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SampleDataGenerator.Builders;
using SampleDataGenerator.Generators;

namespace SampleDataGenerator.Tests.Builders
{
    [TestClass]
    public class PropertyGeneratorBuildersTest
    {
        [TestMethod]
        public void PropertyGeneratorBuilder_Must_return_correct_builder()
        {
            // arrange
            var objectBuilder = new ObjectGeneratorBuilder<TestObject>();

            var sut = new PropertyGeneratorBuilder<TestObject, string>(objectBuilder, x => x.StringProperty1);

            // act
            var builder1 = sut.ChooseFrom("");
            var builder2 = sut.ChooseRandomlyFrom("");
            var builder3 = sut.CreateUsing(() => "");
            var builder4 = sut.CreateUsing(Mock.Of<IObjectGenerator<string>>());

            // assert
            Assert.AreSame(builder1, objectBuilder);
            Assert.AreSame(builder2, objectBuilder);
            Assert.AreSame(builder3, objectBuilder);
            Assert.AreSame(builder4, objectBuilder);
        }

        [TestMethod]
        public void DatePropertyGeneratorBuilder_Must_return_correct_builder()
        {
            // arrange
            var objectBuilder = new ObjectGeneratorBuilder<TestObject>();

            var sut = new DatePropertyGeneratorBuilder<TestObject>(objectBuilder, x => x.DateTimeProperty);

            // act
            var builder = sut.Range(DateTime.Now, DateTime.Now);

            // assert
            Assert.AreSame(builder, objectBuilder);
        }

        [TestMethod]
        public void ArrayPropertyGeneratorBuilder_Must_return_correct_builder()
        {
            // arrange
            var objectBuilder = new ObjectGeneratorBuilder<TestObject>();

            var sut = new ArrayPropertyGeneratorBuilder<TestObject, TestObject>(objectBuilder, x => x.NestedList);

            // act
            var builder = sut.CreateUsing(Mock.Of<IObjectGenerator<TestObject>>(), 1);

            // assert
            Assert.AreSame(builder, objectBuilder);
        }
    }
}