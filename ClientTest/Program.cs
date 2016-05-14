using System;
using Contract;
using RpcLite.Client;

namespace ClientTest
{
	class Program
	{
		static void Main(string[] args)
		{
			var client = RpcClientBase<ITestService>.GetInstance("http://localhost:53189/api/test2/");

			var time = client.Client.GetDateTimeString();
			Console.WriteLine("Time from service is " + time);

			var product = client.Client.GetProductById(1);
			Console.WriteLine(product.Name);

			var testService = client.Client;
			var addedProductId = testService.AddProduct(new Product
			{
				Name = "Book",
				Price = 45,
			});
			Console.WriteLine(addedProductId);

			Console.WriteLine(product.Name);
			Console.ReadLine();
		}
	}
}