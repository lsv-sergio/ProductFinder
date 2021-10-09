namespace ProductFinder.Services
{
	using System;
	using System.Collections.Generic;
	using AtbSearchExecutor;
	using Core;
	using VarusSearchExecutor;

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
			var finderTypes = new List<Type> {
				typeof(AtbFinder),
				typeof(VarusFinder)
			};
			foreach (var finderType in finderTypes) {
				_finders.Add(Activator.CreateInstance(finderType) as IProductFinder);
			}
			// var files = Directory.GetFiles($"{Directory.GetCurrentDirectory()}\\Finders","*.dll",
			// 	SearchOption.TopDirectoryOnly);
			// var finderType = typeof(IProductFinder);
			// foreach (var file in files) {
			// 	var finderAssembly = Assembly.LoadFile(file);
			// 	_finders.AddRange(
			// 		finderAssembly.GetTypes()
			// 		.Where(type => finderType.IsAssignableFrom(type))
			// 		.Select(type => Activator.CreateInstance(finderType) as IProductFinder)
			// 		.ToList());
			// }
		}

		public void Clear() {
			foreach (var finder in _finders) {
				finder.Dispose();
			}
		}
	}
}
