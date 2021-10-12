namespace ProductSearcher.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;
	using System.Threading.Tasks;
	using Core;
	using Microsoft.AspNetCore.Mvc;
	using Models;
	using Services;

	#region Class: ${Name}

	[ApiController]
	[Route("api/[controller]")]
	public class SearchController : ControllerBase
	{

		#region Fields: Private

		private readonly IShopsProvider _shopsProvider;

		#endregion

		#region Constructors: Public

		public SearchController(IShopsProvider shopsProvider) {
			_shopsProvider = shopsProvider;
		}

		#endregion

		#region Methods: Public

		[HttpPost]
		public async Task<ActionResult<SearchResponse[]>> Find([FromBody] SearchRequest searchRequest) {
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

		#endregion

	}

	#endregion

}