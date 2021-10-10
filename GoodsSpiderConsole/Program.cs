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
			var finderType = typeof(IProductFinder);
			CancellationTokenSource cts = new CancellationTokenSource();
			foreach (var file in files) {
				var finderAssembly = Assembly.LoadFile(file);
				var finders = finderAssembly.GetTypes()
					.Where(t => finderType.IsAssignableFrom(t)).ToList();
				result.AddRange(finders.Select(finder => Activator.CreateInstance(finder) as IProductFinder)
					.Select(instance => instance?.Search(productName, cts.Token)));
			}

			return result.ToArray();
		}

		private static async Task Main(string[] args) {
			var productName = args[0];
			var finders = LoadFinders(productName);
			var results = await Task.WhenAll(finders);
			Console.OutputEncoding = Encoding.UTF8;
			foreach (var result in results) {
				if (result.Products == null) {
					continue;
				}
				Console.BackgroundColor = ConsoleColor.DarkRed;
				Console.WriteLine(result.StoreName);
				Console.WriteLine();
				Console.BackgroundColor = ConsoleColor.Black;
				foreach (var product in result.Products) {
					Console.WriteLine(product.Image);
					Console.WriteLine(product.Name);
					Console.WriteLine(product.Price);
					Console.WriteLine(product.Link);
				}
				Console.WriteLine();
			}

			Console.ReadLine();
		}

		#endregion

	}

	#endregion

}
