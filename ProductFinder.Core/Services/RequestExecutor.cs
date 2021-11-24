namespace ProductFinder.Core.Services
{
	using System.Net.Http;
	using System.Threading;
	using System.Threading.Tasks;
	using Interfaces;

	#region Class: RequestExecutor

	public class RequestExecutor : IRequestExecutor
	{

		#region Fields: Private

		private HttpClient _httRequestMock;

		#endregion

		#region Constructors: Public

		public RequestExecutor() { }

		public RequestExecutor(HttpClient httRequestMock) {
			_httRequestMock = httRequestMock;
		}

		#endregion

		#region Properties: Private

		private HttpClient HttpClient => _httRequestMock ??= new HttpClient();

		#endregion

		#region Methods: Public

		public async Task<string> SendRequest(string url, CancellationToken cancellationToken) {
			var response = await HttpClient.GetAsync(url, cancellationToken);
			var content = await response.Content.ReadAsStringAsync(cancellationToken);
			return content;
		}

		#endregion

	}

	#endregion

}
