namespace ProductSearcher.Services
{
	using ProductFinder.Core.Interfaces;

	public interface IProductSearchExecutorFactory
	{
		IProductSearchExecutor Create(IProductParser productParser, ISearchUrlBuilder searchUrlBuilder);
	}
}
