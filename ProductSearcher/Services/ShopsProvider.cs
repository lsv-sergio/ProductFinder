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

		#endregion

		#region Methods: Public

		public void Clear() {
			foreach (var finder in _finders) {
				finder.Dispose();
			}
		}

		public IEnumerable<IProductSearchExecutor> GetShops() {
			return _finders;
		}

		public void Load() {
			var files = Directory.GetFiles($"{Directory.GetCurrentDirectory()}\\ShopIntegration", "*.dll",
				SearchOption.TopDirectoryOnly);
			var finderType = typeof(IProductSearchExecutor);
			foreach (var file in files) {
				var finderAssembly = Assembly.LoadFile(file);
				var types = finderAssembly.GetTypes()
					.Where(type => finderType.IsAssignableFrom(type))
					.ToList();
				foreach (var type in types) {
					_finders.Add(Activator.CreateInstance(type) as IProductSearchExecutor);
				}
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