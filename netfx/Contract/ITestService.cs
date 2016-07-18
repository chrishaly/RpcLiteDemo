using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
	
	public interface ITestService
	{
		string GetDateTimeString();
		int AddProduct(Product product);
		Product GetProductById(int id);
	}
}
