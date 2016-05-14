using RpcLite.TestService;

namespace ClientTest
{
	class Program
	{
		static void Main(string[] args)
		{
			var client = RpcLite.Client.RpcClientBase<ITestService>.GetInstance();
			var p = client.Client.GetDateTimeString();
		}
	}
}
