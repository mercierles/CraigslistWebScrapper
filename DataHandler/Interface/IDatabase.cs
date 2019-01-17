using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandler.Interface
{
	public interface IDatabase
	{
		void addItemsToTable(IItemInformation itemInfo);
		void addItemsToTable(List<IItemInformation> lstItemInfo);
		void submitItemsToDatabase();
	}
}
