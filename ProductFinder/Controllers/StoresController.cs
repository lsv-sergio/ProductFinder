using Microsoft.AspNetCore.Mvc;

namespace ProductFinder.Controllers
{
	using System.Linq;
	using Services;

	[ApiController]
	[Route("api/[controller]")]
	public class StoresController : Controller
	{
		private readonly IFinderStorage _finderStorage;

		public StoresController(IFinderStorage finderStorage) {
			_finderStorage = finderStorage;
		}

		[HttpGet]
		public Store[] Get() {
			return _finderStorage.GetFinders().Select(x => new Store { Name =  x.Name }).ToArray();
		}

		public class Store
		{
			public string Name { get; set; }
		}
	}
}
