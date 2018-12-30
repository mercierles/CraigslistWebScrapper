using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;

namespace WebScrapper
{
	class Program
	{
		static void Main(string[] args)
		{
			//TODO: async this console application to allow for multiple instances to run independently
			//TODO: Fill search options from args (will be retrieved from the gui)
			//Retrieve page arguments for search
			SearchOptions searchOptions = new SearchOptions();
			searchOptions.Category = DataHandler.Enums.Enums.EnumCategory.sss;
			searchOptions.Condition = new List<DataHandler.Enums.Enums.EnumCondition>() { DataHandler.Enums.Enums.EnumCondition.excellent, DataHandler.Enums.Enums.EnumCondition.brandnew, DataHandler.Enums.Enums.EnumCondition.excellent };
			searchOptions.MaxPrice = "1000";
			searchOptions.MinPrice = "10";
			searchOptions.SearchDistance = "200";
			searchOptions.SearchZip = "04957";
			searchOptions.State = "maine";
			searchOptions.Search = "mountain bike";

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
				int listItemCount = resultsContentListItems.Count;
				for (int li = 0; li < listItemCount; li++)
				{
					//Fill Model
					Information itemInfo = new Information();
					itemInfo.ID = resultsContentListItems[li].GetAttributeValue("data-pid", "missing");
					itemInfo.Description = resultsContentListItems[li].SelectSingleNode("descendant::a[contains(@class, 'result-title hdrlnk')]/text()").InnerText.Trim();
					HtmlNodeCollection purchaseLocations = resultsContentListItems[li].SelectNodes("descendant::span[contains(@class, 'result-hood') or contains(@class, 'nearby')]/text()");
					itemInfo.PurchaseLocation = purchaseLocations[0].InnerText.Trim();
					string strPrice = resultsContentListItems[li].SelectSingleNode("descendant::span[contains(@class, 'result-price')]/text()").InnerText.Trim().Replace("$","");
					double dblPrice;
					if (!double.TryParse(strPrice, out dblPrice)) { throw new Exception("Unable to parse double"); }
					itemInfo.Price = dblPrice;
					itemInfo.SearchKey = searchKey;
					Console.WriteLine("DataScrape: " + itemInfo.ID + "," + itemInfo.Description + "," + itemInfo.Price + "," + itemInfo.PurchaseLocation);

					//Write to database
					DataHandler.Oracle database = new DataHandler.Oracle();
					database.writeItemsToDatabase(itemInfo);
				}
				pageCounter++;
				pageURL = nextPageURL(pageURL, itemsPerPage, pageCounter);

			} while (pageCounter <= pageCount);

			Console.WriteLine("Closing Scrapper");
			
		}

		private static string createURL(DataHandler.Interface.ISearchOptions searchOptions)
		{
			//TODO: Put url template in app settings
			string formattedSearchURL = String.Format("https://{0}.craigslist.org/search/{1}?query={2}", searchOptions.State, searchOptions.Category.ToString(), searchOptions.Search);
			if (!string.IsNullOrEmpty(searchOptions.SearchDistance))
			{
				formattedSearchURL = formattedSearchURL + "&search_distance=" + searchOptions.SearchDistance;
			}
			if (!string.IsNullOrEmpty(searchOptions.SearchZip))
			{
				formattedSearchURL = formattedSearchURL + "&postal=" + searchOptions.SearchZip;
			}
			if (!string.IsNullOrEmpty(searchOptions.MinPrice))
			{
				formattedSearchURL = formattedSearchURL + "&min_price=" + searchOptions.MinPrice;
			}
			if (!string.IsNullOrEmpty(searchOptions.MaxPrice))
			{
				formattedSearchURL = formattedSearchURL + "&max_price=" + searchOptions.MaxPrice;
			}
			foreach (DataHandler.Enums.Enums.EnumCondition condition in searchOptions.Condition)
			{
				formattedSearchURL = formattedSearchURL + "&condition=" + (int)condition;
			}

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
