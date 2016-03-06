using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleDataGenerator.Builders;

namespace SampleDataGenerator.Tests.Builders
{
    [TestClass]
    public class ObjectGeneratorBuildersTest
    {
        [TestMethod]
        public void ObjectGeneratorBuilder_Must_return_correct_builder()
        {
            // arrange
            var sut = new ObjectGeneratorBuilder<TestObject>();

            // act
            var dateBuilder = sut.For(x => x.DateTimeProperty);
            var propertyBuilder = sut.For(x => x.StringProperty1);
            var arrayBuilder = sut.For(x => x.NestedList);

            // assert
            Assert.IsInstanceOfType(dateBuilder, typeof(DatePropertyGeneratorBuilder<TestObject>));
            Assert.IsInstanceOfType(propertyBuilder, typeof(PropertyGeneratorBuilder<TestObject, string>));
            Assert.IsInstanceOfType(arrayBuilder, typeof(ArrayPropertyGeneratorBuilder<TestObject, TestObject>));
        }
    }
}