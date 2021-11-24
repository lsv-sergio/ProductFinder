namespace ProductFinder.Core.Models
{
	using System.Collections.Generic;

	#region Class: SearchResponse

	public class SearchResponse
	{

		#region Properties: Public

		public IList<Product> Products { get; init; }
		public string StoreName { get; init; }

		#endregion

	}

	#endregion

}
