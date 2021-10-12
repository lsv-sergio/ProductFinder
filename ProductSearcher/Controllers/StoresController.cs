namespace ProductSearcher.Controllers
{
	using System.Linq;
	using Microsoft.AspNetCore.Mvc;
	using Services;

	#region Class: ${Name}

	[ApiController]
	[Route("api/[controller]")]
	public class StoresController : Controller
	{

		#region Fields: Private

		private readonly IShopsProvider _shopsProvider;

		#endregion

		#region Class: Nested

		public class Store
		{

			#region Properties: Public

			public string Name { get; set; }

			#endregion

		}

		#endregion

		#region Constructors: Public

		public StoresController(IShopsProvider shopsProvider) {
			_shopsProvider = shopsProvider;
		}

		#endregion

		#region Methods: Public

		[HttpGet]
		public Store[] Get() {
			return _shopsProvider.GetShops()
				.Select(x => new Store { Name = x.Name })
				.ToArray();
		}

		#endregion

	}

	#endregion

}