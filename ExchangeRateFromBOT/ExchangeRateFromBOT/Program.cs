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
			var xmldoc = service.GetXml();
			var items = service.GetItems(xmldoc);
			Console.ReadLine();
		}
	}
}
