namespace ProductFinder.Services
{
	using System;
	using System.Threading;
	using System.Threading.Tasks;
	using Microsoft.Extensions.Hosting;

	public class ShopsLoader: IHostedService
	{
		private readonly IShopsProvider _shopsProvider;

		public ShopsLoader(IShopsProvider shopsProvider) {
			_shopsProvider = shopsProvider;
		}
		public Task StartAsync(CancellationToken cancellationToken) {
			return Task.Run(() => {
				_shopsProvider.Load();
			}, cancellationToken);
		}

		public Task StopAsync(CancellationToken cancellationToken) {
			return Task.Run(() =>_shopsProvider.Clear(), cancellationToken);
		}
	}
}
