namespace Core
{
	using System;
	using System.Threading;
	using System.Threading.Tasks;

	public interface IProductFinder: IDisposable
	{
		public string Name { get; }
		Task<SearchResponse> Search(string productName, CancellationToken token);
	}
}
