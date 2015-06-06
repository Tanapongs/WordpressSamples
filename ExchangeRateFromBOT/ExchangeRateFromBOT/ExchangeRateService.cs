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
