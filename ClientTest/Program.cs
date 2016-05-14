using System;
using RpcLite.Client;
using RpcLite.TestService;

namespace ClientTest
{
	class Program
	{
		static void Main(string[] args)
		{
			var client = RpcClientBase<ITestService>.GetInstance("http://localhost:53189/api/test/");
			var time = client.Client.GetDateTimeString();
			Console.WriteLine("Time from service is " + time);
			Console.ReadLine();
		}
	}
}
