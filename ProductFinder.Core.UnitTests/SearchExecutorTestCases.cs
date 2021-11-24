namespace ProductFinder.Core.UnitTests
{
	using System;
	using System.Threading;
	using Interfaces;
	using NSubstitute;
	using Services;
	using Xunit;

	public class SearchExecutorTestCases
	{
		[Fact]
		public void Search_ShouldReturns_ListOfProducts() {
			var requestExecutor = Substitute.For<IRequestExecutor>();
			var productParser = Substitute.For<IProductParser>();
			var searchUrlBuilder = Substitute.For<ISearchUrlBuilder>();
			var searchValue = "Test";
			var searchExecutor = new SearchExecutor(requestExecutor, productParser, searchUrlBuilder);
			searchExecutor.Search(searchValue, CancellationToken.None);
			requestExecutor.Received(1)
				.SendRequest(Arg.Any<string>(), Arg.Any<CancellationToken>());
			productParser.Received(1)
				.Parse(Arg.Any<string>());
			searchUrlBuilder.Received(1)
				.Build(Arg.Is<string>(
					x => x.Equals(searchValue, StringComparison.InvariantCultureIgnoreCase)));
		}
	}
}
