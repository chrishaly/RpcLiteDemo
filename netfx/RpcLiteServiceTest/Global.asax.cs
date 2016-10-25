using System;
using RpcLite.Config;

namespace RpcLiteServiceTest
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{
			RpcInitializer.Initialize(builder => builder
				.UseService<TestService2>("TestService2", "api/service/")
				.UseServicePaths("api/")
				);
		}
	}
}