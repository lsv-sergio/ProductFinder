namespace VarusIntegration
{
	using ProductFinder.Core.Models;
	using ProductFinder.Core.Services;

	public class VarusProductParser: BaseProductParser<VarusProduct>
	{
		public VarusProductParser() :
			base("products", ConvertToProduct) { }

		private static Product ConvertToProduct(VarusProduct varusProduct) => new Product {
			Id = varusProduct.Id,
			Name = varusProduct.Name,
			Price = varusProduct.Price,
			Image = varusProduct.Image,
			Link = varusProduct.Link
		};
	}
}
