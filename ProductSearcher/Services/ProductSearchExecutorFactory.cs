namespace ProductSearcher.Services
{
	using ProductFinder.Core.Interfaces;
	using ProductFinder.Core.Services;

	#region Class: ${Name}

	public class ProductSearchExecutorFactory : IProductSearchExecutorFactory
	{

		#region Fields: Private

		private readonly IRequestExecutor _requestExecutor;

		#endregion

		#region Constructors: Public

		public ProductSearchExecutorFactory(IRequestExecutor requestExecutor) {
			_requestExecutor = requestExecutor;
		}

		#endregion

		#region Methods: Public

		public IProductSearchExecutor Create(IProductParser productParser, ISearchUrlBuilder searchUrlBuilder) {
			return new SearchExecutor(_requestExecutor, productParser, searchUrlBuilder);
		}

		#endregion

	}

	#endregion

}
