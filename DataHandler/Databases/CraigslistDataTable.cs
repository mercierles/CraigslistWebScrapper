using DataHandler.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandler.Databases
{
	public class CraigslistDataTable
	{
		private DataTable table;
		public DataTable Table{ get { return table; } }

		public CraigslistDataTable()
		{
			if (table == null)
			{
				table = CreateTable();
			}
		}

		public void AddItemsToDatatable(List<IItemInformation> lstItemInfo)
		{
			DataRow row;
			foreach (IItemInformation item in lstItemInfo)
			{
				row = table.NewRow();
				row["CRAIGSLIST_ITEM_ID"] = item.ID;
				row["DESCRIPTION"] = item.Description;
				row["ITEM_LOCATION"] = item.PurchaseLocation;
				row["PRICE"] = item.Price;
				row["SEARCH_KEY"] = item.SearchKey;
				table.Rows.Add(row);
			}
		}

		public void AddItemsToDatatable(IItemInformation itemInfo)
		{
			DataRow row = table.NewRow();
			row["CRAIGSLIST_ITEM_ID"] = itemInfo.ID;
			row["DESCRIPTION"] = itemInfo.Description;
			row["ITEM_LOCATION"] = itemInfo.PurchaseLocation;
			row["PRICE"] = itemInfo.Price;
			row["SEARCH_KEY"] = itemInfo.SearchKey;
			table.Rows.Add(row);
		}

		private DataTable CreateTable()
		{
			DataTable dt = new DataTable("CraigslistItems");
			// Declare variables for DataColumn and DataRow objects.
			DataColumn column;

			column = new DataColumn();
			column.DataType = Type.GetType("System.String");
			column.ColumnName = "CRAIGSLIST_ITEM_ID";
			column.Unique = true;
			// Add the Column to the DataColumnCollection.
			dt.Columns.Add(column);

			column = new DataColumn();
			column.DataType = Type.GetType("System.String");
			column.ColumnName = "DESCRIPTION";
			// Add the Column to the DataColumnCollection.
			dt.Columns.Add(column);

			column = new DataColumn();
			column.DataType = Type.GetType("System.String");
			column.ColumnName = "ITEM_LOCATION";
			// Add the Column to the DataColumnCollection.
			dt.Columns.Add(column);

			column = new DataColumn();
			column.DataType = Type.GetType("System.Double");
			column.ColumnName = "PRICE";
			// Add the Column to the DataColumnCollection.
			dt.Columns.Add(column);

			column = new DataColumn();
			column.DataType = Type.GetType("System.String");
			column.ColumnName = "SEARCH_KEY";
			// Add the Column to the DataColumnCollection.
			dt.Columns.Add(column);

			return dt;
		}
	}
}
