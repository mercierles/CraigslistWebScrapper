using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;
using System.Diagnostics;

namespace WebScrapper
{
	class Program
	{
		static void Main(string[] args)
		{
			
			//TODO: async this console application to allow for multiple instances to run independently
			//TODO: Fill search options from args (will be retrieved from the gui)
			//Retrieve page arguments for search
			SearchOptions searchOptions = new SearchOptions(args);


			//Create URL
			string url = createURL(searchOptions);
			if (string.IsNullOrEmpty(url)) { throw new NullReferenceException("No url to perform search on"); }

			//Load Settings
			loadSettings();

			//Load Page & run scrapper
			loadPage(url, searchOptions.Search);
		}

		
		private static void loadSettings()
		{
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
		}

		private static void loadPage(string pageURL, string searchKey)
		{

			//Allow Https sites to be loaded into html agility pack
			WebClient client = new WebClient();


			//Scrape Page for Ukulele data
			int itemCount = 1;
			int pageCount = 1; //Total items divided by items per page is the page count
			int pageCounter = 1;
			double totalItems = 0;
			int itemsPerPage = 120;

			Console.WriteLine("Starting Scrapper");
			do
			{
				Console.WriteLine("Scraping Page: " + pageCounter + "/" + pageCount);

				Uri myUri = new Uri(pageURL, UriKind.Absolute);
				HtmlDocument document = new HtmlDocument();
				document.LoadHtml(client.DownloadString(myUri));

				//Set page count
				if (pageCounter == 1 && document.DocumentNode.SelectSingleNode("//*[@class=\"button pagenum\"]").ChildNodes.Count > 1)
				{
					string strTotalItems = document.DocumentNode.SelectSingleNode("//*[@class=\"button pagenum\"]/span[@class=\"totalcount\"]").InnerText.Trim();
					if (!double.TryParse(strTotalItems, out totalItems)) throw new Exception("Unable to parse page count into int");
					pageCount = (int)Math.Ceiling((totalItems / itemsPerPage));
				}

				//Parse Document info
				HtmlNodeCollection resultsContentListItems = document.DocumentNode.SelectNodes("//*[@id=\"sortable-results\"]/ul/li");
				if (resultsContentListItems == null) { throw new NullReferenceException("Search returned nothing"); }
				int listItemCount = resultsContentListItems.Count;
				for (int li = 0; li < listItemCount; li++)
				{
					//Fill Model
					Information itemInfo = new Information();
					itemInfo.ID = resultsContentListItems[li].GetAttributeValue("data-pid", "missing");
					HtmlNode node = resultsContentListItems[li].SelectSingleNode("descendant::a[contains(@class, 'result-title hdrlnk')]/text()");
					itemInfo.Description = (node != null ? node.InnerText.Trim(): "");
					HtmlNodeCollection purchaseLocations = resultsContentListItems[li].SelectNodes("descendant::span[contains(@class, 'result-hood') or contains(@class, 'nearby')]/text()");
					itemInfo.PurchaseLocation = (purchaseLocations != null ? purchaseLocations[0].InnerText.Trim() : "");
					node = resultsContentListItems[li].SelectSingleNode("descendant::span[contains(@class, 'result-price')]/text()");
					string strPrice = (node != null ? node.InnerText.Trim().Replace("$","") : "0");
					double dblPrice;
					if (!double.TryParse(strPrice, out dblPrice)) { throw new Exception("Unable to parse double"); }
					itemInfo.Price = dblPrice;
					itemInfo.SearchKey = searchKey;
					Console.WriteLine("DataScrape Item(" + itemCount + "\\" + totalItems+ "): " + itemInfo.ID + "," + itemInfo.Description + "," + itemInfo.Price + "," + itemInfo.PurchaseLocation + "," + searchKey);

					//Write to database
					DataHandler.Oracle database = new DataHandler.Oracle();
					database.writeItemsToDatabase(itemInfo);
					itemCount++;
				}
				pageCounter++;
				pageURL = nextPageURL(pageURL, itemsPerPage, pageCounter);

			} while (pageCounter <= pageCount);

			Console.WriteLine("Closing Scrapper");
			
		}

		private static string createURL(DataHandler.Interface.ISearchOptions searchOptions)
		{
			//TODO: Put url template in app settings
			string formattedSearchURL = String.Format("{0}search/{1}?", searchOptions.URL, Enum.GetName(typeof(DataHandler.Enums.Enums.EnumCategory),searchOptions.Category));
			if (!string.IsNullOrEmpty(searchOptions.Search)){
				formattedSearchURL = formattedSearchURL + "query=" + searchOptions.Search +"&";
			}
			if (!string.IsNullOrEmpty(searchOptions.SearchDistance))
			{
				formattedSearchURL = formattedSearchURL + "search_distance=" + searchOptions.SearchDistance + "&";
			}
			if (!string.IsNullOrEmpty(searchOptions.SearchZip))
			{
				formattedSearchURL = formattedSearchURL + "postal=" + searchOptions.SearchZip + "&";
			}
			if (!string.IsNullOrEmpty(searchOptions.MinPrice))
			{
				formattedSearchURL = formattedSearchURL + "min_price=" + searchOptions.MinPrice + "&";
			}
			if (!string.IsNullOrEmpty(searchOptions.MaxPrice))
			{
				formattedSearchURL = formattedSearchURL + "max_price=" + searchOptions.MaxPrice + "&";
			}
			foreach (DataHandler.Enums.Enums.EnumCondition condition in searchOptions.Condition)
			{
				formattedSearchURL = formattedSearchURL + "condition=" + (int)condition + "&";
			}
			formattedSearchURL = formattedSearchURL.TrimEnd('&');
			//https://maine.craigslist.org/search/ata?search_distance=1&min_price=1&max_price=1000&condition=10&condition=20&condition=30&condition=40
			//https://maine.craigslist.org/search/sss?query=ukulele&search_distance=1&min_price=1&max_price=1000&condition=10&condition=20&condition=30&condition=40
			//https://maine.craigslist.org//search/0?query=''&search_distance=1&postal=''&min_price=0&max_price=100000&condition=10&condition=20&condition=30&condition=40&condition=50&condition=60
			//if (!Debugger.IsAttached)
			//	Debugger.Launch();

			return formattedSearchURL;
		}

		private static string nextPageURL(string url, int itemsPerPage, int pageCounter)
		{
			if (string.IsNullOrEmpty(url))
			{
				throw new NullReferenceException("url is empty");
			}
			return url + "&s="+(itemsPerPage*(pageCounter-1));
		}

	}
}
