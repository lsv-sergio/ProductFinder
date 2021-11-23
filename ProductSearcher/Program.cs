namespace ProductSearcher
{
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.Extensions.Hosting;

	#region Class: ${Name}

	public class Program
	{

		#region Methods: Public

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

		public static void Main(string[] args) {
			CreateHostBuilder(args)
				.Build()
				.Run();
		}

		#endregion

	}

	#endregion

}