using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleDataGenerator.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDataGenerator.Tests.Sources
{
	[TestClass]
	public class DomainGeneratorTest
	{
		[TestMethod]
		public void TestDomainGenerator()
		{
			// arrange
			var generator = new DomainGenerator();

			// act
			var result = generator.Generate();

			// assert
			Assert.IsTrue(result.Split('.').Count() > 1);
		}
	}
}