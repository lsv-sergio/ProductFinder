namespace VarusIntegration
{
	using ProductFinder.Core.Interfaces;

	public class VarusSearchUrlBuilder: ISearchUrlBuilder
	{

		public string Build(string searchValue) =>
			$"https://autocomplete.diginetica.net/autocomplete?st={searchValue}&apiKey=BRX1D2Q3H9&shuffle=true&strategy=advanced,zero_queries&productsSize=20&regionId=1110&forIs=true&showUnavailable=false&withContent=false&withSku=false";
	}
}
