namespace GoodsSpiderConsole
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using System.Text;
	using System.Threading;
	using System.Threading.Tasks;
	using Core;
	using NovusSearchExecutor;

	#region Class: Program

	internal class Program
	{

		#region Methods: Private

		private static Task<SearchResponse>[] LoadFinders(string productName) {
			if (!Directory.Exists(".\\Finders")) {
				return Array.Empty<Task<SearchResponse>>();
			}

			var result = new List<Task<SearchResponse>>();
			var files = Directory.GetFiles($"{Directory.GetCurrentDirectory()}\\Finders","*.dll",
				SearchOption.TopDirectoryOnly);
			var finderType = typeof(IProductSearchExecutor);
			CancellationTokenSource cts = new CancellationTokenSource();
			foreach (var file in files) {
				var finderAssembly = Assembly.LoadFile(file);
				var finders = finderAssembly.GetTypes()
					.Where(t => finderType.IsAssignableFrom(t)).ToList();
				// result.AddRange(finders.Select(finder => Activator.CreateInstance(finder) as IProductSearchExecutor)
					// .Select(instance => instance?.Search(productName, cts.Token)));
			}

			return result.ToArray();
		}

		private static async Task Main(string[] args) {
			var productName = "Test";
			var executor = new NovusSearchExecutor(null);
			//var results = await executor.Search(productName, new CancellationToken());
			Console.OutputEncoding = Encoding.UTF8;
		}

		#endregion

	}

	#endregion

}
