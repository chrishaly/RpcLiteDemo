using System;
using RpcLite.AspNet;

namespace HelloRpcLiteService
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{
			RpcInitializer.Initialize(builder => builder
				.UseService<ProductService>("ProductService", "api/service/")
				.UseServicePaths("api/")
				);
		}
	}
}