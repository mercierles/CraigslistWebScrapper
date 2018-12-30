using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataHandler.Interface;
using DataHandler.Enums;

namespace WebScrapper
{
	class SearchOptions : ISearchOptions
	{
		public string State { get; set; }
		public Enums.EnumCategory Category { get; set; }
		public string Search { get; set; }
		public List<Enums.EnumCondition> Condition { get; set; }
		public string MinPrice { get; set; }
		public string MaxPrice { get; set; }
		public string SearchDistance { get; set; }
		public string SearchZip { get; set; }


		//https://maine.craigslist.org/search/ppa?query=car&search_distance=200&postal=04957&min_price=10&max_price=1000&condition=10&condition=20&condition=30
	}
}
