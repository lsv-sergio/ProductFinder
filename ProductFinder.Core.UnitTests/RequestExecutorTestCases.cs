namespace ProductFinder.Core.UnitTests
{
	using System.Net;
	using System.Net.Http;
	using System.Threading;
	using System.Threading.Tasks;
	using NUnit.Framework;
	using Services;

	[TestFixture]
	public class RequestExecutorTestCases
	{
		private class MockHttpMessageHandler : HttpMessageHandler
		{
			public string Url { get; private set; }
			public int NumberOfCalls { get; private set; }

			protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
				CancellationToken cancellationToken)
			{
				NumberOfCalls++;
				Url = request?.RequestUri?.AbsoluteUri;
				return Task.FromResult(new HttpResponseMessage {
					StatusCode = HttpStatusCode.Accepted
				});
			}
		}
		[Test]
		public async Task SendRequest_ShouldSendHttpRequest() {
			var httpMessageHandler = new MockHttpMessageHandler();
			var httRequestMock = new HttpClient(httpMessageHandler);
			var requestExecutor = new RequestExecutor(httRequestMock);
			var url = "https://www.test-url.com/";
			await requestExecutor.SendRequest(url, CancellationToken.None);
			Assert.AreEqual(url, httpMessageHandler.Url);
			Assert.AreEqual(1, httpMessageHandler.NumberOfCalls);
		}
	}
}
