namespace AtbIntegration
{
	using Newtonsoft.Json;

	internal record AtbProduct
	{

		#region Properties: Public

		[JsonProperty("id")] public string Id { get; set; }

		[JsonProperty("name")] public string Name { get; set; }

		[JsonProperty("price")] public decimal Price { get; set; }

		[JsonProperty("picture")] public string Picture { get; set; }

		#endregion

	}
}
