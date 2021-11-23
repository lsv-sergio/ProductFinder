namespace ProductSearcher.Services
{
	using Core.Interfaces;

	public interface IProductSearchExecutorFactory
	{
		IProductSearchExecutor Create(IProductParser productParser, ISearchUrlBuilder searchUrlBuilder);
	}
}
