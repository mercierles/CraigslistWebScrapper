using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;

namespace UkuleleWebScrapper
{
	class Program
	{
		static void Main(string[] args)
		{

			loadPage();
		}

		private static void loadPage()
		{

			//Allow Https sites to be loaded into html agility pack
			HtmlWeb web = new HtmlWeb()
			{
				PreRequest = request =>
				{
					// Make any changes to the request object that will be used.
					request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
					return true;
				}
			};


			//Scrape Page for ukulele data
			int pageCount = 1;
			int pageCounter = 1;
			do
			{
				HtmlDocument document = web.Load("https://www.amazon.com/s/ref=sr_pg_" + pageCounter.ToString() +"?fst=as%3Aon&rh=n%3A11091801%2Cn%3A14733114011%2Cn%3A11971501%2Ck%3Aukulele&page="+ pageCounter.ToString()+"&sort=relevancerank&keywords=ukulele&ie=UTF8&qid=1545711444");
				if(pageCounter == 1)
				{
					HtmlNodeCollection pageCountNode = document.DocumentNode.SelectNodes("//*[@id=\"pagn\"]//*[@class=\"pagnDisabled\"]");
					if(!int.TryParse(pageCountNode[0].InnerText, out pageCount)) throw new Exception("Unable to parse page count into int");
				}
				HtmlNodeCollection ukeNodeUL = document.DocumentNode.SelectNodes("//*[@id=\"s-results-list-atf\"]");
				int ulListItemCount = ukeNodeUL[0].ChildNodes.Count;
				for(int li = 0; li < ulListItemCount; li++)
				{
					string result = ukeNodeUL[0].ChildNodes[li].GetAttributeValue("id", "");
					HtmlNodeCollection ukeNode = document.DocumentNode.SelectNodes("//*[@id=\""+result+"\"]");
					String ukeID = ukeNode[0].GetAttributeValue("data-asin", "noDataKey");
					Console.WriteLine(ukeID);
				}
				pageCounter++;

			} while (pageCounter <= pageCount);

			Console.ReadKey();
		}
	}
}
