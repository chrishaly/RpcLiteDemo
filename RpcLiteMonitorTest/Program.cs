using System;
using Contract;
using RpcLite;
using RpcLite.AspNetCore;
using RpcLite.Client;
using RpcLite.Config;
using RpcLite.Monitor;
using RpcLite.Service;

namespace RpcLiteMonitorTest
{
	public class Program
	{
		public static void Main(string[] args)
		{
			RpcInitializer.Initialize(builder =>
				builder.UseMonitor<TestConsoleMonitorFactory>(null, null));

			//run project RpcLiteServiceCoreTest first
			var client = ClientFactory.GetInstance<ITestService>("http://localhost:5000/api/service/");
			try
			{
				var dateTime = client.GetDateTimeString();
				Console.WriteLine("DateTime from server is " + dateTime);

				var a = client.AddProduct(new Product
				{
					Id = 1,
					Name = "Test",
					Price = 99
				});
				Console.WriteLine("id of Product added is " + a);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			Console.ReadLine();
		}
	}

	class TestConsoleMonitorFactory : IMonitorFactory
	{
		public IMonitor CreateMonitor(AppHost appHost, RpcConfig config)
		{
			return new TestConsoleMonitor();
		}
	}


	class TestConsoleMonitor : IMonitor
	{
		public void Dispose()
		{
		}

		public IServiceMonitorSession GetServiceSession(ServiceContext context)
		{
			return new TestConsoleServiceSession();
		}

		public IClientMonitorSession GetClientSession()
		{
			return new TestConsoleClientSession();
		}
	}

	class TestConsoleServiceSession : IServiceMonitorSession
	{
		public void BeginRequest(ServiceContext context)
		{
			Console.WriteLine("BeginRequest at " + DateTime.Now);
		}

		public void EndRequest(ServiceContext context)
		{
			Console.WriteLine("BeginRequest at " + DateTime.Now);
		}
	}

	class TestConsoleClientSession : IClientMonitorSession
	{
		public void OnInvoking(ClientContext request)
		{
			Console.WriteLine("OnInvoking at " + DateTime.Now);
		}

		public void OnInvoked(ClientContext request)
		{
			Console.WriteLine("OnInvoked at " + DateTime.Now);
		}

		public void OnSerializing(ClientContext request)
		{
			Console.WriteLine("OnSerializing at " + DateTime.Now);
		}

		public void OnSerialized(ClientContext request)
		{
			Console.WriteLine("OnSerialized at " + DateTime.Now);
		}
	}
}
