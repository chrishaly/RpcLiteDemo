using System;

namespace HelloRpcLiteService
{
	public class ProductService : IProductService
	{
		public string GetDateTimeString()
		{
			return DateTime.Now.ToString();
		}
	}
}