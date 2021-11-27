namespace AtbIntegration
{
	using ProductFinder.Core.Interfaces;

	public class AtbSearchUrlBuilder: ISearchUrlBuilder
	{

		public string Build(string searchValue) =>
			$"https://api.multisearch.io/?id=11280&lang=uk&location=1016&m=1625945047281&q=med4ph&query={searchValue}&s=large&uid=53d6d396-ab01-462a-93ac-001f89f137a1";
	}
}
