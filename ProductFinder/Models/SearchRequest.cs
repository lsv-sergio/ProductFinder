namespace ProductFinder.Models
{
	using System.Collections.Generic;

	public class SearchRequest
	{
		public string ProductName { get; set; }
		public string[] SearchIn { get; set; }
	}
}
