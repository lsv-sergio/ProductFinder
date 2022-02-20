namespace ProductSearcher.Models
{
	using System.Reflection;
	using System.Runtime.Loader;

	#region Class: ${Name}

	public class ShopIntegrationLoadContext : AssemblyLoadContext
	{

		#region Fields: Private

		private readonly AssemblyDependencyResolver _resolver;

		#endregion

		#region Constructors: Public

		public ShopIntegrationLoadContext(string pluginPath) {
			_resolver = new AssemblyDependencyResolver(pluginPath);
		}

		#endregion

		#region Methods: Protected

		protected override Assembly Load(AssemblyName assemblyName) {
			var assemblyPath = _resolver.ResolveAssemblyToPath(assemblyName);
			return assemblyPath != null ? LoadFromAssemblyPath(assemblyPath) : null;
		}

		#endregion

	}

	#endregion

}
