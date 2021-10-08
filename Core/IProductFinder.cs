namespace Core
{
	using System;
	using System.Threading.Tasks;

	public interface IProductFinder: IDisposable
	{
		Task<SearchResponse> Search(string productName);
	}
}
