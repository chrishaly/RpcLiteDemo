using System;
using System.Globalization;
using Contract;

namespace RpcLiteServiceCoreTest
{
	public class TestService2 : ITestService
	{
		public string GetDateTimeString()
		{
			return DateTime.Now.ToString(CultureInfo.InvariantCulture);
		}

		public int AddProduct(Product product)
		{
			return 1;
		}

		public Product GetProductById(int id)
		{
			return new Product
			{
				Id = id,
				Name = "Test Product Name",
				Price = (decimal)(new Random().NextDouble() * 100),
			};
		}
	}
}