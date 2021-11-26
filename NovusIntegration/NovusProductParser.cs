namespace NovusIntegration
{
	using ProductFinder.Core.Models;
	using ProductFinder.Core.Services;

	public class NovusProductParser: BaseProductParser<NovusProduct>
	{
		public NovusProductParser() :
			base("results", ConvertToProduct) { }

		private static Product ConvertToProduct(NovusProduct novusProduct) =>
			new Product {
				Id = novusProduct.Id,
				Name = novusProduct.Name,
				Price = novusProduct.Price / 100,
				Image = novusProduct.Image,
				Link = novusProduct.Link
			};
	}
}
