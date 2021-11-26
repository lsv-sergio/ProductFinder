namespace NovusIntegration
{
	using Newtonsoft.Json;

	public record NovusProduct
	{

		#region Properties: Public

		[JsonProperty("ean")] public string Id { get; set; }

		[JsonProperty("title")] public string Name { get; set; }

		[JsonProperty("price")] public decimal Price { get; set;}

		[JsonProperty("web_url")] public string Link { get; set; }

		[JsonProperty("sku")] public string Image { get; set; }

		#endregion

	}
}
