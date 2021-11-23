namespace Core.Services
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Interfaces;
	using Models;
	using Newtonsoft.Json.Linq;

	#region Class: ${Name}

	public abstract class BaseProductParser<T> : IProductParser
	{

		#region Fields: Private

		private readonly Func<T, Product> _productFactory;
		private readonly string _productsAttributeName;

		#endregion

		#region Constructors: Protected

		protected BaseProductParser(string productsAttributeName, Func<T, Product> productFactory) {
			_productsAttributeName = productsAttributeName;
			_productFactory = productFactory;
		}

		#endregion

		#region Methods: Public

		public List<Product> Parse(string content) {
			var raw = JObject.Parse(content);
			var products = raw[_productsAttributeName]
				?.ToObject<List<T>>();
			if (products == null) {
				throw new Exception("Error response");
			}

			return products.Select(_productFactory)
				.ToList();
		}

		#endregion

	}

	#endregion

}