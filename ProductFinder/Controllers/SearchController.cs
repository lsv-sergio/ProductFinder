using Microsoft.AspNetCore.Mvc;

namespace ProductFinder.Controllers
{
	using System.Collections.Generic;
	using System.Threading;
	using System.Threading.Tasks;
	using Core;
	using Services;

	[ApiController]
	[Route("api/[controller]")]
	public class SearchController : ControllerBase
	{
		private readonly IFinderStorage _finderStorage;

		public SearchController(IFinderStorage finderStorage) {
			_finderStorage = finderStorage;
		}
		[HttpGet("{productName}")]
		public async Task<ActionResult<SearchResponse[]>> Get(string productName) {
			var foundResult = new List<SearchResponse>();
			CancellationTokenSource cts = new CancellationTokenSource();
			foreach (IProductFinder productFinder in _finderStorage.GetFinders()) {
				foundResult.Add(await productFinder.Search(productName, cts.Token));
			}
			return Ok(foundResult);
		}
	}
}
