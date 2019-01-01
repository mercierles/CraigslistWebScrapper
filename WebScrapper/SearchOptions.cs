using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataHandler.Interface;
using DataHandler.Enums;
using System.Diagnostics;

namespace WebScrapper
{
	class SearchOptions : ISearchOptions
	{
		public string URL { get; set; }
		public Enums.EnumCategory Category { get; set; }
		public string Search { get; set; }
		public List<Enums.EnumCondition> Condition { get; set; }
		public string MinPrice { get; set; }
		public string MaxPrice { get; set; }
		public string SearchDistance { get; set; }
		public string SearchZip { get; set; }

		public SearchOptions(string[] args)
		{
			//if (!Debugger.IsAttached)
			//	Debugger.Launch();

			URL = !string.IsNullOrEmpty(args[0]) ? args[0] : "https://maine.craigslist.org/";
			if (!string.IsNullOrEmpty(args[1])) { Search = args[1]; }
			if (!string.IsNullOrEmpty(args[2])) {
				Enums.EnumCategory enumCat;
				if (Enum.TryParse(args[2], out enumCat))
				{
					Category = enumCat;
				}
			}
			if (!string.IsNullOrEmpty(args[3])) { MinPrice = args[3]; }
			if (!string.IsNullOrEmpty(args[4])) { MaxPrice = args[4]; }
			if (!string.IsNullOrEmpty(args[5])) { SearchZip = args[5]; }
			if (!string.IsNullOrEmpty(args[6])) { SearchDistance = args[6]; }

			if (Condition == null) { Condition = new List<Enums.EnumCondition>(); }
			int argCounter = 7;
			do
			{
				if (args.Count() > 7 && !string.IsNullOrEmpty(args[7]))
				{
					Enums.EnumCondition enumCondition;
					if (Enum.TryParse(args[argCounter], out enumCondition))
					{
						Condition.Add(enumCondition);
					}
				}
				argCounter++;
			} while (argCounter < args.Count());
		}

		public SearchOptions()
		{
			Category = DataHandler.Enums.Enums.EnumCategory.sss;
			Condition = new List<DataHandler.Enums.Enums.EnumCondition>() { DataHandler.Enums.Enums.EnumCondition.excellent, DataHandler.Enums.Enums.EnumCondition.brandnew, DataHandler.Enums.Enums.EnumCondition.excellent };
			MinPrice = "1";
			MaxPrice = "100000";
			SearchDistance = "200";
			SearchZip = "04957";
			URL = "https://maine.craigslist.org/";
			Search = "";
		}

		//https://maine.craigslist.org/search/ppa?query=car&search_distance=200&postal=04957&min_price=10&max_price=1000&condition=10&condition=20&condition=30
	}
}
