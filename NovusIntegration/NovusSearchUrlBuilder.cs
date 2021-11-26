namespace NovusIntegration
{
	using ProductFinder.Core.Interfaces;

	public class NovusSearchUrlBuilder: ISearchUrlBuilder
	{

		public string Build(string searchValue) =>
			$"https://stores-api.zakaz.ua/stores/48201070/products/search/?q={searchValue}";
	}
}
