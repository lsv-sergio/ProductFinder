namespace ProductFinder.Services
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using Core;

	public interface IShopsProvider
	{
		IEnumerable<IProductSearchExecutor> GetShops();
		void Load();
		void Clear();
	}

	public class ShopsProvider : IShopsProvider
	{
		private readonly List<IProductSearchExecutor> _finders = new List<IProductSearchExecutor>();

		public IEnumerable<IProductSearchExecutor> GetShops() {
			return _finders;
		}

		public void Load() {
			var files = Directory.GetFiles($"{Directory.GetCurrentDirectory()}\\ShopIntegration","*.dll",
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

		public void Clear() {
			foreach (var finder in _finders) {
				finder.Dispose();
			}
		}
	}
}
