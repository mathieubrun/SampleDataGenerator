namespace SampleDataGenerator.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EnumerableExtensionsTest
    {
        [TestMethod]
        public void Loop_must_expand_list_if_needed()
        {
            var count = 4;

            // arrange
            var list = Enumerable.Range(0, 2).Loop();

            // act
            var result = list.Take(count).ToList();

            // assert
            Assert.AreEqual(count, result.Count());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void Loop_must_throw_ArgumentNullException()
        {
            var list = EnumerableExtensions.Loop((IEnumerable<object>)null).ToList();
        }

        [TestMethod]
        public void Loop_must_not_expand_empty_list()
        {
            var count = 4;

            // arrange
            var list = EnumerableExtensions.Loop(Enumerable.Empty<int>());

            // act
            var result = list.Take(count).ToList();

            // assert
            Assert.AreEqual(0, result.Count());
        }
    }
}
