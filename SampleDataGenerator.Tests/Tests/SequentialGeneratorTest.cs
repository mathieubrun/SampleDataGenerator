﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleDataGenerator.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDataGenerator.Tests.Tests
{
    [TestClass]
    public class SequentialGeneratorTest
    {
        [TestMethod]
        public void Loop_must_expand_list_if_needed()
        {
            // arrange
            var count = 4;
            var range = Enumerable.Range(0, 2).ToArray();
            var generator = new SequencialGenerator<int>(range);
            
            // act
            var result = Enumerable.Range(0, count).Select(x => generator.Get());

            // assert
            Assert.AreEqual(count, result.Count());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void Loop_must_throw_ArgumentNullException()
        {
            int[] range = null;

            var generator = new SequencialGenerator<int>(range);
        }

        [TestMethod]
        public void Loop_must_not_expand_empty_list()
        {
            // arrange
            var count = 4;
            var range = Enumerable.Empty<object>().ToArray();
            var generator = new SequencialGenerator<object>(range);

            // act
            var result = Enumerable.Range(0, count).Select(x => generator.Get());

            // assert
            Assert.IsTrue(result.All(x => x == null));
        }
    }
}
