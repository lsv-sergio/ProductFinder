namespace Core
{
	using System.Collections.Generic;
	using System.Threading;
	using System.Threading.Tasks;

	public interface IProductSearchExecutor
	{
		public string Name { get; set; }
		Task<List<Product>> Search(string productName, CancellationToken token);
	}
}