namespace ProductFinder.Services
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using Core;

	public interface IFinderStorage
	{
		IEnumerable<IProductFinder> GetFinders();
		void Load();

		void Clear();
	}

	public class FinderStorage : IFinderStorage
	{
		private readonly List<IProductFinder> _finders = new List<IProductFinder>();

		public IEnumerable<IProductFinder> GetFinders() {
			return _finders;
		}

		public void Load() {
			var files = Directory.GetFiles($"{Directory.GetCurrentDirectory()}\\Finders","*.dll",
				SearchOption.TopDirectoryOnly);
			var finderType = typeof(IProductFinder);
			foreach (var file in files) {
				var finderAssembly = Assembly.LoadFile(file);
				var types = finderAssembly.GetTypes()
					.Where(type => finderType.IsAssignableFrom(type))
					.ToList();
				foreach (var type in types) {
					_finders.Add(Activator.CreateInstance(type) as IProductFinder);
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
