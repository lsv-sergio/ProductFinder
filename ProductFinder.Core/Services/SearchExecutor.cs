namespace ProductFinder.Core.Services
{
	using System.Collections.Generic;
	using System.Threading;
	using System.Threading.Tasks;
	using Interfaces;
	using Models;

	#region Class: SearchExecutor

	public class SearchExecutor : IProductSearchExecutor
	{

		#region Fields: Private

		private readonly IProductParser _productParser;
		private readonly IRequestExecutor _requestExecutor;
		private readonly ISearchUrlBuilder _searchUrlBuilder;

		#endregion

		#region Constructors: Public

		public SearchExecutor(IRequestExecutor requestExecutor,
			IProductParser productParser, ISearchUrlBuilder searchUrlBuilder) {
			_requestExecutor = requestExecutor;
			_productParser = productParser;
			_searchUrlBuilder = searchUrlBuilder;
		}

		#endregion

		#region Properties: Public

		public string Name { get; set; }

		#endregion

		#region Methods: Public

		public async Task<List<Product>> Search(string test, CancellationToken cancellationToken) {
			var url = _searchUrlBuilder.Build(test);
			var rawResult = await _requestExecutor.SendRequest(url, cancellationToken);
			return _productParser.Parse(rawResult);
		}

		#endregion

	}

	#endregion

}
