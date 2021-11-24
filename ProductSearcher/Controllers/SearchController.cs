namespace ProductSearcher.Controllers
{
	using System;
	using System.Linq;
	using System.Threading;
	using System.Threading.Tasks;
	using Hubs;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.SignalR;
	using Models;
	using ProductFinder.Core.Interfaces;
	using ProductFinder.Core.Models;
	using Services;

	#region Class: ${Name}

	[ApiController]
	[Route("api/[controller]")]
	public class SearchController : ControllerBase
	{

		#region Fields: Private

		private readonly IHubContext<SearchResultHub> _hub;

		private readonly IShopsProvider _shopsProvider;

		#endregion

		#region Constructors: Public

		public SearchController(IShopsProvider shopsProvider, IHubContext<SearchResultHub> hub) {
			_shopsProvider = shopsProvider;
			_hub = hub;
		}

		#endregion

		#region Methods: Public

		[HttpPost]
		public ActionResult Find([FromBody] SearchRequest searchRequest) {
			CancellationTokenSource cts = new CancellationTokenSource();
			foreach (IProductSearchExecutor productFinder in _shopsProvider.GetShops()) {
				if (!searchRequest.SearchIn.Any(storeName => storeName.Equals(productFinder.Name,
					StringComparison.InvariantCultureIgnoreCase))) {
					continue;
				}

				Task.Run(async () => {
					var products = await productFinder.Search(searchRequest.ProductName, cts.Token);
					var response = new SearchResponse {
						StoreName = productFinder.Name,
						Products = products.OrderBy(x => x.Price)
							.ToList()
					};
					await _hub.Clients.Client(searchRequest.ClientId)
						.SendCoreAsync("result-received", new object[] { response }, cts.Token);
				}, cts.Token);
			}

			return Ok();
		}

		#endregion

	}

	#endregion

}
