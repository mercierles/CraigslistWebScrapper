using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandler
{
	public interface IItemInformation
	{
		string ID { get; set; }
		string PurchaseLocation { get; set; }
		string Description { get; set; }
		double Price { get; set; }
		string SearchKey { get; set; }
	}
}
