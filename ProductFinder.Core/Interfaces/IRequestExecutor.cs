namespace ProductFinder.Core.Interfaces
{
	using System.Threading;
	using System.Threading.Tasks;

	public interface IRequestExecutor
	{
		Task<string> SendRequest(string url, CancellationToken cancellationToken);
	}
}
