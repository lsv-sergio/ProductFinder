namespace ProductSearcher.Services
{
	using System.Threading;
	using System.Threading.Tasks;
	using Microsoft.Extensions.Hosting;

	#region Class: ${Name}

	public class ShopsLoader : IHostedService
	{

		#region Fields: Private

		private readonly IShopsProvider _shopsProvider;

		#endregion

		#region Constructors: Public

		public ShopsLoader(IShopsProvider shopsProvider) {
			_shopsProvider = shopsProvider;
		}

		#endregion

		#region Methods: Public

		public Task StartAsync(CancellationToken cancellationToken) {
			return Task.Run(() => { _shopsProvider.Load(); }, cancellationToken);
		}

		public Task StopAsync(CancellationToken cancellationToken) {
			return Task.Run(() => _shopsProvider.Clear(), cancellationToken);
		}

		#endregion

	}

	#endregion

}