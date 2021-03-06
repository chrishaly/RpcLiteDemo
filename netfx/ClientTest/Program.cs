﻿using System;
using Contract;
using RpcLite.Client;
using RpcLite.Config;

namespace ClientTest
{
	class Program
	{
		static void Main(string[] args)
		{
			RpcInitializer.Initialize(new RpcConfig());

			//change url as real address of RpcLiteServiceTest when running
			var client = ClientFactory.GetInstance<ITestService>("http://localhost:53189/api/service/");

			var time = client.GetDateTimeString();
			Console.WriteLine("Time from service is " + time);

			var product = client.GetProductById(1);
			Console.WriteLine(product.Name);

			var testService = client;
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