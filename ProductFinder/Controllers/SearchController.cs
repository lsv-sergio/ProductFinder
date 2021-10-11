using Microsoft.AspNetCore.Mvc;

namespace ProductFinder.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;
	using System.Threading.Tasks;
	using Core;
	using Models;
	using Services;


	[ApiController]
	[Route("api/[controller]")]
	public class SearchController : ControllerBase
	{
		private readonly IShopsProvider _shopsProvider;

		public SearchController(IShopsProvider shopsProvider) {
			_shopsProvider = shopsProvider;
		}
		[HttpPost]
		public async Task<ActionResult<SearchResponse[]>> Find([FromBody]SearchRequest searchRequest) {
			var foundResult = new List<SearchResponse>();
			CancellationTokenSource cts = new CancellationTokenSource();
			foreach (IProductSearchExecutor productFinder in _shopsProvider.GetShops()) {
				if (!searchRequest.SearchIn.Any(storeName => storeName.Equals(productFinder.Name,
					StringComparison.InvariantCultureIgnoreCase))) {
					continue;
				}
				foundResult.Add(await productFinder.Search(searchRequest.ProductName, cts.Token));
			}
			return Ok(foundResult);
		}
	}
}
