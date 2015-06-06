using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateFromBOT
{
	class Program
	{
		static void Main(string[] args)
		{
			var service = new ExchangeRateService();
			var result = service.GetXml();
			Console.ReadLine();
		}
	}
}
