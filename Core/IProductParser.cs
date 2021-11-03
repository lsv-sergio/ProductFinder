namespace Core
{
	using System.Collections.Generic;

	public interface IProductParser
	{
		List<Product> Parse(string content);
	}
}