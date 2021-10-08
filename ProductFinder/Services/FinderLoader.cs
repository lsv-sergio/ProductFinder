namespace ProductFinder.Services
{
	using System;
	using System.Threading;
	using System.Threading.Tasks;
	using Microsoft.Extensions.Hosting;

	public class FinderLoader: IHostedService
	{
		private readonly IFinderStorage _finderStorage;

		public FinderLoader(IFinderStorage finderStorage) {
			_finderStorage = finderStorage;
		}
		public Task StartAsync(CancellationToken cancellationToken) {
			return Task.Run(() => {
				_finderStorage.Load();
			}, cancellationToken);
		}

		public Task StopAsync(CancellationToken cancellationToken) {
			return Task.Run(() =>_finderStorage.Clear(), cancellationToken);
		}
	}
}
