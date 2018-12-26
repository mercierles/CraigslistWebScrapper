using System;
using System.IO;
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
			string path = ".../.../Data/UkuleleData_"+ DateTime.Now.ToString("MMDDYYYYhhmmss") +".csv";
			Directory.CreateDirectory(Path.GetDirectoryName(path));
			System.IO.StreamWriter sw = new System.IO.StreamWriter(path);

			//Allow Https sites to be loaded into html agility pack
			WebClient client = new WebClient();
			HtmlWeb web = new HtmlWeb()
			{
				PreRequest = request =>
				{
					// Make any changes to the request object that will be used.
					request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
					ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
					return true;
				}
			};


			//Scrape Page for ukulele data
			int pageCount = 1; //Total items divided by items per page is the page count
			int pageCounter = 1;
			double totalItems = 0;
			int itemsPerPage = 90;
			do
			{
				//string url = "https://www.guitarcenter.com/Ukuleles.gc#pageName=subcategory-page&N=19556&Nao=90&recsPerPage=90&postalCode=04957&radius=100&profileCountryCode=US&profileCurrencyCode=USD";
				string formattedURL = "https://www.guitarcenter.com/Ukuleles.gc#pageName=subcategory-page&N=19556&Nao=" + (itemsPerPage * (pageCounter - 1)).ToString() + "&recsPerPage=" + itemsPerPage.ToString() + "&postalCode=04957&radius=100&profileCountryCode=US&profileCurrencyCode=USD";
				Uri myUri = new Uri(formattedURL, UriKind.Absolute);
				
				//HtmlDocument document = web.Load(doc);

				HtmlDocument document = new HtmlDocument();
				document.LoadHtml(client.DownloadString(myUri));
				Console.WriteLine("Starting Scrapper");
				if (pageCounter == 1)
				{
					string strTotalItems = document.DocumentNode.SelectSingleNode("//*[@class=\"searchTotalResults\"]/text()").InnerText;
					if (!double.TryParse(strTotalItems, out totalItems)) throw new Exception("Unable to parse page count into int");
					pageCount = (int)Math.Ceiling((totalItems / itemsPerPage));
				}
				HtmlNodeCollection resultsContentListItems = document.DocumentNode.SelectNodes("//*[@id=\"resultsContent\"]/div/ol/li");
				int listItemCount = resultsContentListItems.Count;
				for(int li = 0; li < listItemCount; li++)
				{
					//Save data to csv file
					string ukeID = resultsContentListItems[li].SelectSingleNode("descendant::var[contains(@class, 'hidden productId')]/text()[normalize-space()]").InnerText.Replace("\n", "");
					string ukeDesc = resultsContentListItems[li].SelectSingleNode("descendant::div[contains(@class, 'productTitle')]/a/text()[normalize-space()]").InnerText.Replace("\n", "");
					string ukePrice = resultsContentListItems[li].SelectSingleNode("descendant::div[contains(@class, 'priceContainer mainPrice')]/span/text()[normalize-space()]").InnerText.Replace("\n", "");
					Console.WriteLine("DataScrape: " + ukeID + "," + ukeDesc + "," + ukePrice);
					sw.WriteLine(ukeID + "," + ukeDesc + "," + ukePrice);
					
				}
				pageCounter++;

			} while (pageCounter <= pageCount);

			Console.WriteLine("Closing Scrapper");
			sw.Close();
			
		}

	}
}
