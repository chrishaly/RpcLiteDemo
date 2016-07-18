using System;
using System.Globalization;

namespace HelloRpcLiteServiceCore
{
	public class TestService1
	{
		public string GetDateTimeString()
		{
			return DateTime.Now.ToString(CultureInfo.InvariantCulture);
		}

	}
}