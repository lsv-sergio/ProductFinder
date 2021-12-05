namespace AtbIntegration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Newtonsoft.Json.Linq;
	using ProductFinder.Core.Interfaces;
	using ProductFinder.Core.Models;

	public class AtbProductParser: IProductParser
	{
		#region Methods: Private

		private static JEnumerable<JToken> GetFoundItems(string content) {
			var rawObject = JObject.Parse(content);
			if (!rawObject["results"]
				?.HasValues ?? true) {
				return new JEnumerable<JToken>();
			}

			var results = rawObject["results"];
			if (!results["item_groups"]
				?.HasValues ?? true) {
				return new JEnumerable<JToken>();
			}

			var itemGroups = results["item_groups"];
			if (!itemGroups[0]
				?.HasValues ?? true) {
				return new JEnumerable<JToken>();
			}

			var rootItemGroup = itemGroups[0];
			if (!rootItemGroup["items"]
				?.HasValues ?? true) {
				return new JEnumerable<JToken>();
			}

			return rootItemGroup["items"]
				.Children<JToken>();
		}

		private static IEnumerable<Product> TryConvertProduct(JArray item) {
			try {
				var atbProducts = item.ToObject<IList<AtbProduct>>();
				return atbProducts?.Select(atbProduct => new Product {
					Id = atbProduct.Id,
					Name = atbProduct.Name,
					Price = atbProduct.Price,
					Image = atbProduct.Picture
				});
			} catch {
				return null;
			}
		}

		private static IEnumerable<Product> TryConvertProduct(JObject item) {
			try {
				var atbProduct = item.ToObject<AtbProduct>();
				if (atbProduct == null) {
					return null;
				}
				return new[] {
						new Product {
							Id = atbProduct.Id,
							Name = atbProduct.Name,
							Price = atbProduct.Price,
							Image = atbProduct.Picture
						}
					};
			} catch {
				return null;
			}
		}

		#endregion

		public List<Product> Parse(string content) {
			var rawItems = GetFoundItems(content);
			var foundProducts = new List<Product>();
			foreach (var item in rawItems) {
				var products = item is JArray array ? TryConvertProduct(array) : TryConvertProduct(item as JObject);
				if (products != null) {
					foundProducts.AddRange(products);
				}
			}

			return foundProducts;
		}
	}
}
