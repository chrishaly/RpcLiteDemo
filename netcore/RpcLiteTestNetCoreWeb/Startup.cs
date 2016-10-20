using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace RpcLiteTestNetCoreWeb
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			//1. add routing Middleware
			services.AddRouting();
		}

		public void Configure(IApplicationBuilder app)
		{
			//2. config RpcLite
			app.UseRpcLite(builder =>
				builder
					.UseService<TestService1>("", "api/service/")
					.UseServicePaths("api/")
			);

			app.Run(async context =>
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
