using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataHandler;

namespace WebScrapper
{
	class Information : IItemInformation
	{
		public string ID { get; set; }

		public string PurchaseLocation { get; set; }

		public string Description { get; set; }

		public double Price { get; set; }

		public string SearchKey { get; set; }
	}
}
