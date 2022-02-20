namespace ProductSearcher.Services
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using Models;

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
			return fileName.Replace("Integration", "");
		}

		private static object GetProductParserType(Type targetType, Assembly assembly) {
			foreach (var type in assembly.GetTypes()) {
				if (targetType.IsAssignableFrom(type)) {
					return Activator.CreateInstance(type);
				}
			}

			return null;
		}

		private static Assembly LoadAssembly(string file) {
			var loadContext = new ShopIntegrationLoadContext(file);
			return loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(file)));
		}

		private List<IProductSearchExecutor> Load() {
			var files = Directory.GetFiles($"{Directory.GetCurrentDirectory()}\\ShopIntegration", "*Integration.dll",
				SearchOption.AllDirectories);
			var finders = new List<IProductSearchExecutor>();
			var productParserType = typeof(IProductParser);
			var searchUrlBuilderType = typeof(ISearchUrlBuilder);
			foreach (var file in files) {
				var searchExecutor = TryGetSearchExecutor(file, productParserType, searchUrlBuilderType);
				if (searchExecutor == null) {
					continue;
				}

				finders.Add(searchExecutor);
			}

			return finders;
		}

		private IProductSearchExecutor TryGetSearchExecutor(string file, Type productParserType,
			Type searchUrlBuilderType) {
			try {
				var assembly = LoadAssembly(file);
				var productParser = GetProductParserType(productParserType, assembly) as IProductParser;
				var searchUrlBuilder = GetProductParserType(searchUrlBuilderType, assembly) as ISearchUrlBuilder;
				if (productParser is null || searchUrlBuilder is null) {
					return null;
				}

				var searchExecutor = _productSearchExecutorFactory.Create(productParser, searchUrlBuilder);
				searchExecutor.Name = GetNameFromFile(file);
				return searchExecutor;
			} catch {
				return null;
			}
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
