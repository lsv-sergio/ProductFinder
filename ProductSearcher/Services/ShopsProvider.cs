namespace ProductSearcher.Services
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using Core;

	#region Class: ${Name}

	public class ShopsProvider : IShopsProvider
	{

		#region Fields: Private

		private readonly List<IProductSearchExecutor> _finders = new List<IProductSearchExecutor>();
		private readonly IRequestExecutor _requestExecutor;

		#endregion

		#region Constructors: Public

		public ShopsProvider(IRequestExecutor requestExecutor) {
			_requestExecutor = requestExecutor;
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

		#endregion

		#region Methods: Public

		public void Clear() {
			// foreach (var finder in _finders) {
			// 	finder.Dispose();
			// }
		}

		public IEnumerable<IProductSearchExecutor> GetShops() {
			return _finders;
		}

		public void Load() {
			var files = Directory.GetFiles($"{Directory.GetCurrentDirectory()}\\ShopIntegration", "*.dll",
				SearchOption.TopDirectoryOnly);
			var productParserType = typeof(IProductParser);
			var searchUrlBuilderType = typeof(ISearchUrlBuilder);
			foreach (var file in files) {
				var finderAssembly = Assembly.LoadFile(file);
				var allTypes = finderAssembly.GetTypes();
				var productParser = allTypes.First(type => productParserType.IsAssignableFrom(type));
				var searchUrlBuilder = allTypes.First(type => searchUrlBuilderType.IsAssignableFrom(type));
				var searchExecutor = new SearchExecutor(_requestExecutor,
					Activator.CreateInstance(productParser) as IProductParser,
					Activator.CreateInstance(searchUrlBuilder) as ISearchUrlBuilder);
				_finders.Add(searchExecutor);
				searchExecutor.Name = GetNameFromFile(file);
			}
		}

		#endregion

	}

	#endregion

	public interface IShopsProvider
	{
		IEnumerable<IProductSearchExecutor> GetShops();
		void Load();
		void Clear();
	}
}
