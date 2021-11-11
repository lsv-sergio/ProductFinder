namespace Core.Interfaces
{
	using System.Collections.Generic;
	using Models;

	public interface IProductParser
	{
		List<Product> Parse(string content);
	}
}