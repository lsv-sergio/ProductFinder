namespace Core.Interfaces
{
	using System.Collections.Generic;
	using System.Threading;
	using System.Threading.Tasks;
	using Models;

	public interface IProductSearchExecutor
	{
		public string Name { get; set; }
		Task<List<Product>> Search(string productName, CancellationToken token);
	}
}