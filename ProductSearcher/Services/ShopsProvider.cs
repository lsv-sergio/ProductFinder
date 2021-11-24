namespace ProductSearcher.Services
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using ProductFinder.Core.Interfaces;

	#region Class: ${Name}

	public class ShopsProvider : IShopsProvider
	{

		#region Fields: Private

		private readonly IProductSearchExecutorFactory _productSearchExecutorFactory;
		private List<IProductSearchExecutor> _finders;

		#endregion

		private static readonly object Lock = new object();

		#region Constructors: Public

		public ShopsProvider(IProductSearchExecutorFactory productSearchExecutorFactoryFactory) {
			_productSearchExecutorFactory = productSearchExecutorFactoryFactory;
		}

		#endregion

		#region Methods: Private

		private static string GetNameFromFile(string file) {
			var fileName = file.Split("\\", StringSplitOptions.RemoveEmptyEntries)
				.Last()
				.Split(".")
				.First();
			return fileName.Replace("Integrator", "");
		}

		private List<IProductSearchExecutor> Load() {
			var files = Directory.GetFiles($"{Directory.GetCurrentDirectory()}\\ShopIntegration", "*.dll",
				SearchOption.TopDirectoryOnly);
			var finders = new List<IProductSearchExecutor>();
			var productParserType = typeof(IProductParser);
			var searchUrlBuilderType = typeof(ISearchUrlBuilder);
			foreach (var file in files) {
				var finderAssembly = Assembly.LoadFile(file);
				var allTypes = finderAssembly.GetTypes();
				var productParser = allTypes.First(type => productParserType.IsAssignableFrom(type));
				var searchUrlBuilder = allTypes.First(type => searchUrlBuilderType.IsAssignableFrom(type));
				var searchExecutor = _productSearchExecutorFactory.Create(
					Activator.CreateInstance(productParser) as IProductParser,
					Activator.CreateInstance(searchUrlBuilder) as ISearchUrlBuilder);
				searchExecutor.Name = GetNameFromFile(file);
				finders.Add(searchExecutor);
			}

			return finders;
		}

		#endregion

		#region Methods: Public

		public IEnumerable<IProductSearchExecutor> GetShops() {
			if (_finders == null) {
				lock (Lock) {
					if (_finders != null) {
						return _finders;
					}

					_finders = Load();
					return _finders;
				}
			}

			return _finders;
		}

		#endregion

	}

	#endregion

	public interface IShopsProvider
	{
		IEnumerable<IProductSearchExecutor> GetShops();
	}
}
