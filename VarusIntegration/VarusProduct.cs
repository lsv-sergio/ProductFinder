namespace VarusIntegration
{
	using Newtonsoft.Json;

	public record VarusProduct
	{

		#region Properties: Public

		[JsonProperty("id")] public string Id { get; set; }

		[JsonProperty("name")] public string Name { get; set; }

		[JsonProperty("price")] public decimal Price { get; set; }

		[JsonProperty("link_url")] public string Link { get; set; }

		[JsonProperty("image_url")] public string Image { get; set; }

		#endregion

	}
}
