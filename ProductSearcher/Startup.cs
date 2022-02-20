namespace ProductSearcher
{
	using System;
	using System.Runtime.Loader;
	using Hubs;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Hosting;
	using Models;
	using ProductFinder.Core.Interfaces;
	using ProductFinder.Core.Services;
	using Services;

	#region Class: ${Name}

	public class Startup
	{

		#region Constructors: Public

		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		#endregion

		#region Properties: Public

		public IConfiguration Configuration { get; }

		#endregion

		#region Methods: Public

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			} else {
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				// app.UseHsts();
			}

			// app.UseHttpsRedirection();
			app.UseStaticFiles();
			if (!env.IsDevelopment()) {
				app.UseSpaStaticFiles();
			}

			app.UseRouting();
			app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
			app.UseEndpoints(endpoint => { endpoint.MapHub<SearchResultHub>("/hub"); });
			app.UseSpa(spa => { spa.Options.DefaultPage = "/index.html"; });
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {
			services.AddSingleton<IShopsProvider, ShopsProvider>();
			services.AddTransient<IRequestExecutor, RequestExecutor>();
			services.AddTransient<IProductSearchExecutorFactory, ProductSearchExecutorFactory>();
			services.AddSingleton<Func<string, AssemblyLoadContext>>(file => new ShopIntegrationLoadContext(file));
			// services.AddHostedService<ShopsLoader>();
			services.AddControllers();
			// In production, the Angular files will be served from this directory
			services.AddSpaStaticFiles(configuration => { configuration.RootPath = "wwwroot"; });
			services.AddSignalR();
		}

		#endregion

	}

	#endregion

}
