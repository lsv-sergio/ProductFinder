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
		private readonly IFinderStorage _finderStorage;

		public SearchController(IFinderStorage finderStorage) {
			_finderStorage = finderStorage;
		}
		[HttpPost]
		public async Task<ActionResult<SearchResponse[]>> Find([FromBody]SearchRequest searchRequest) {
			var foundResult = new List<SearchResponse>();
			CancellationTokenSource cts = new CancellationTokenSource();
			foreach (IProductFinder productFinder in _finderStorage.GetFinders()) {
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
