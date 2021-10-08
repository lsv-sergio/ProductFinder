namespace Core
{
	using System.Collections.Generic;

	public class SearchResponse
	{

		#region Properties: Public

		public IList<Product> Products { get; init; }
		public string StoreName { get; init; }

		#endregion

	}
}