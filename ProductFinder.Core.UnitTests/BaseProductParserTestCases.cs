namespace ProductFinder.Core.UnitTests
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Models;
	using Newtonsoft.Json;
	using NUnit.Framework;
	using Services;

	[TestFixture]
	public class BaseProductParserTestCases
	{
		private class TestProduct
		{
			[JsonProperty("name")]
			public string Name { get; set; }

		}

		private class TestBaseProductParser : BaseProductParser<TestProduct>
		{

			public TestBaseProductParser(string productsAttributeName, Func<TestProduct, Product> productFactory) :
				base(productsAttributeName, productFactory) { }
		}
		[Test]
		public void Parse_ShouldReturnProductCollection() {
			var productName1 = "TestProduct1";
			var productName2 = "TestProduct2";
			var rawProducts = new List<TestProduct> {
				new TestProduct {
					Name = productName1
				},
				new TestProduct {
					Name = productName2
				}
			};
			var testAttributeName = "TestAttributeName";
			Product FactoryFunc(TestProduct testProduct) => new Product { Name = testProduct.Name };
			var parser = new TestBaseProductParser(testAttributeName, FactoryFunc);
			var actualProducts = parser.Parse(JsonConvert.SerializeObject(new {
				TestAttributeName = rawProducts
			}));
			var expectedProducts = new List<Product> {
				new Product {
					Name = productName1
				},
				new Product {
					Name = productName2
				}
			};
			expectedProducts.ForEach(expectedProduct => {
				actualProducts.Remove(actualProducts.First(x => x.Name.Equals(expectedProduct.Name)));
			});
			Assert.AreEqual(0, actualProducts.Count);
		}
	}
}
