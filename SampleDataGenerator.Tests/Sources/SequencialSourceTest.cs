using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleDataGenerator.Sources;

namespace SampleDataGenerator.Tests.Sources
{
    [TestClass]
    public class SequentialSourceTest
    {
        [TestMethod]
        public void Loop_must_expand_list_if_needed()
        {
            // arrange
            var count = 4;
            var range = Enumerable.Range(0, 2).ToArray();
            var generator = new SequencialSource<int>(range);

            // act
            var result = Enumerable.Range(0, count).Select(x => generator.Get());

            // assert
            Assert.AreEqual(count, result.Count());
        }

        [TestMethod]
        public void Loop_must_expand_list_if_needed_for_get()
        {
            // arrange
            var count = 4;
            var range = Enumerable.Range(0, 2).ToArray();
            var generator = new SequencialSource<int>(range);

            // act
            var result = generator.Get(count);

            // assert
            Assert.AreEqual(count, result.Count());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void Loop_must_throw_ArgumentNullException()
        {
            int[] range = null;

            var generator = new SequencialSource<int>(range);
        }

        [TestMethod]
        public void Loop_must_not_expand_empty_list()
        {
            // arrange
            var count = 4;
            var range = Enumerable.Empty<object>().ToArray();
            var generator = new SequencialSource<object>(range);

            // act
            var result = Enumerable.Range(0, count).Select(x => generator.Get());

            // assert
            Assert.IsTrue(result.All(x => x == null));
        }
    }
}