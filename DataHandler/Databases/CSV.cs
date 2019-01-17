using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataHandler.Interface;
using System.IO;

namespace DataHandler
{
	public class CSV : IDatabase
	{
		private string path = ".../.../Data/UkuleleData_" + DateTime.Now.ToString("MMddyyyyhhmmss") + ".csv";
		public StringBuilder sb = new StringBuilder();
		public CSV()
		{
			sb.Append("Item ID,");
			sb.Append("Description,");
			sb.Append("Price,");
			sb.Append("PurchaseLocation,");
			sb.Append("SearchKey");
			sb.AppendLine();
			Directory.CreateDirectory(Path.GetDirectoryName(path));
		}

		public void addItemsToTable(List<IItemInformation> lstItemInfo)
		{
			System.IO.StreamWriter sw = new System.IO.StreamWriter(path);
			using (sw)
			{
				foreach (IItemInformation item in lstItemInfo)
				{
					sb.Append(item.ID);
					sb.Append(",");
					string description = string.IsNullOrEmpty(item.Description) ? "" : item.Description.Replace(",", " ");
					sb.Append(description);
					sb.Append(",");
					sb.Append(item.Price);
					sb.Append(",");
					string purchaseLocation = string.IsNullOrEmpty(item.PurchaseLocation) ? "" : item.PurchaseLocation.Replace(",", " ");
					sb.Append(purchaseLocation);
					sb.Append(",");
					string searchKey = string.IsNullOrEmpty(item.SearchKey) ? "" : item.SearchKey.Replace(",", " ");
					sb.Append(searchKey);
					sb.AppendLine();
				}
				sw.Close();
			}
		}

		public void addItemsToTable(IItemInformation itemInfo)
		{
			sb.Append(itemInfo.ID);
			sb.Append(",");
			string description = string.IsNullOrEmpty(itemInfo.Description) ? "" : itemInfo.Description.Replace(",", " ");
			sb.Append(description);
			sb.Append(",");
			sb.Append(itemInfo.Price);
			sb.Append(",");
			string purchaseLocation = string.IsNullOrEmpty(itemInfo.PurchaseLocation) ? "" : itemInfo.PurchaseLocation.Replace(",", " ");
			sb.Append(purchaseLocation);
			sb.Append(",");
			string searchKey = string.IsNullOrEmpty(itemInfo.SearchKey)?"": itemInfo.SearchKey.Replace(",", " ");
			sb.Append(searchKey);
			sb.AppendLine();
		}

		public void submitItemsToDatabase()
		{
			System.IO.StreamWriter sw = new System.IO.StreamWriter(path);
			using (sw)
			{
				sw.Write(sb.ToString());
				sw.Close();
			}
		}
	}
}
