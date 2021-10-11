using Microsoft.AspNetCore.Mvc;

namespace ProductFinder.Controllers
{
	using System.Linq;
	using Services;

	[ApiController]
	[Route("api/[controller]")]
	public class StoresController : Controller
	{
		private readonly IShopsProvider _shopsProvider;

		public StoresController(IShopsProvider shopsProvider) {
			_shopsProvider = shopsProvider;
		}

		[HttpGet]
		public Store[] Get() {
			return _shopsProvider.GetShops().Select(x => new Store { Name =  x.Name }).ToArray();
		}

		public class Store
		{
			public string Name { get; set; }
		}
	}
}
