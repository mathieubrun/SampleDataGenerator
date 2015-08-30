using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleDataGenerator.Sources;
using System;
using System.Linq;

namespace SampleDataGenerator.Tests.Sources
{
	[TestClass]
	public class EmailGeneratorTest
	{
		[TestMethod]
		public void TestEmailGenerator()
		{
			// arrange
			var generator = new EmailGenerator();
			var firstNames = StaticData.FirstNames;

			// act
			var result = generator.Generate().Split('@');

			// assert
			Assert.AreEqual(2, result.Length, "Result should looks like email and contain @ symbol");
			Assert.IsTrue(firstNames.Contains(result[0]), "Username should be taken from first names");
		}
	}
}