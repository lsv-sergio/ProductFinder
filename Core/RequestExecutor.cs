namespace Core
{
	using System.Net.Http;
	using System.Threading;
	using System.Threading.Tasks;

	#region Class: ${Name}

	public class RequestExecutor : IRequestExecutor
	{

		#region Methods: Public

		public async Task<string> SendRequest(string url, CancellationToken cancellationToken) {
			using var httpClient = new HttpClient();
			var response = await httpClient.GetAsync(url, cancellationToken);
			var content = await response.Content.ReadAsStringAsync(cancellationToken);
			return content;
		}

		#endregion

	}

	#endregion

}