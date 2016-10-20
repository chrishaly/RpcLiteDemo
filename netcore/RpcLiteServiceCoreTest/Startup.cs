using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RpcLiteServiceTest;

namespace RpcLiteServiceCoreTest
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			//1. add routing Middleware
			services.AddRouting();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole();

			//2. config RpcLite
			app.UseRpcLite(builder =>
				builder
					.UseService<TestService1>("", "api/service/")
					.UseServicePaths("api/")
			);

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.Run(async (context) =>
			{
				await context.Response.WriteAsync(@"
<style>
	a:visited {
		color: blue;
	}
</style>

Hello World! 
<br /> 
<div style='font-size: 1.5em'>
<a href='api/service/'>api list</a><br /> 
<a href='api/service/GetProductById'>invoke api GetProductById</a><br /> 
</div>
");
			});
		}
	}
}
