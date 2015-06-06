using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ExchangeRateFromBOT
{
	public class ExchangeRateService
	{


		public List<ExchangeRateItem> GetItems(XmlDocument xmldoc)
		{
			var result = new List<ExchangeRateItem>();

			XmlNodeList items = xmldoc.GetElementsByTagName("item");

			foreach (XmlNode item in items)
			{
				var rate = new ExchangeRateItem();

				foreach (XmlNode des in item.ChildNodes)
				{
					switch (des.Name)
					{
						case "description":
							{
								var warr = des.InnerXml.Split('=');
								var ratedes = warr[1].Trim().Split(' ');
								rate.Unit = Convert.ToDecimal(ratedes[0]);
								break;
							}
						case "cb:targetCurrency": rate.Currency = des.InnerXml.ToUpper(); break;
						case "cb:value": rate.Value = Convert.ToDecimal(des.InnerXml); break;
					}

				}

				result.Add(rate);
			}

			return result;
		}



		public XmlDocument GetXml()
		{
			const string url = "http://www2.bot.or.th/RSS/fxrates/fxrate-all.xml";

			var uri = new Uri(url, UriKind.Absolute);
			var wr = (HttpWebRequest)WebRequest.Create(uri);
			wr.UseDefaultCredentials = true;
			wr.PreAuthenticate = true;
			wr.Credentials = CredentialCache.DefaultCredentials;
			wr.Timeout = 1000 * 60 * 5; // = 5 นาที

			using (var resp = wr.GetResponse())
			{
				using (var reader = new XmlTextReader(resp.GetResponseStream()))
				{
					reader.XmlResolver = null;
					var xmldoc = new XmlDocument();
					xmldoc.Load(reader);
					return xmldoc;
				}
			}			
		}

	}





}
