namespace NovusIntegration.UnitTests
{
	using NovusIntegration;
	using NUnit.Framework;

	public class NovusSearchUrlBuilderTestCases
	{

		[Test]
		public void Build_ShouldReturnsCorrectUrl() {
			var builder = new NovusSearchUrlBuilder();
			string testValue = "Test";
			string actualValue = builder.Build(testValue);
			string expectedValue = $"https://stores-api.zakaz.ua/stores/48201070/products/search/?q={testValue}";
			Assert.AreEqual(expectedValue, actualValue);
		}
	}
}
