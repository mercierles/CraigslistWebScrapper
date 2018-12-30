using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Oracle.ManagedDataAccess.Client;

namespace DataHandler
{
    public class Oracle
    {
		private OracleConnection connection = null;

		//TODO Move to .config file
		private const string CONNECTIONSTRING = "User Id=system; password=Password1;Data Source=localhost:1521/DB1; Pooling=false;";

		public Oracle()
		{
			//connectToOracleDatabase();
		}


		private OracleConnection connectToOracleDatabase()
		{
			if (connection == null)
			{
				connection = new OracleConnection();
				connection.ConnectionString = CONNECTIONSTRING;
				connection.Open();
			}

			return connection;
		}

		public void closeDatabase()
		{
			connection.Close();
		}

		public void writeItemsToDatabase(IItemInformation itemInfo)
		{
			connectToOracleDatabase();

			OracleCommand cmd = connection.CreateCommand();
			cmd.CommandText = "INSERT INTO CRAIGSLISTITEMS (ITEM_ID, CRAIGSLIST_ITEM_ID,DESCRIPTION,ITEM_LOCATION,PRICE,SEARCH_KEY) VALUES(NEXT_ITEMSEQ_ID.nextval,:ID,:DESCRIPTION,:LOCATION,:PRICE,:KEY)";

			cmd.Parameters.Add(new OracleParameter("ID", itemInfo.ID));
			cmd.Parameters.Add(new OracleParameter("DESCRIPTION", itemInfo.Description));
			cmd.Parameters.Add(new OracleParameter("LOCATION", itemInfo.PurchaseLocation));
			cmd.Parameters.Add(new OracleParameter("PRICE", itemInfo.Price));
			cmd.Parameters.Add(new OracleParameter("KEY", itemInfo.SearchKey));

			int rowsUpdated = cmd.ExecuteNonQuery();
			if (rowsUpdated == 0)
			{
				throw new Exception("Failed to add data to database");
			}

			closeDatabase();
		}

		public void writeItemsToDatabase(List<IItemInformation> lstItemInfo)
		{
			connectToOracleDatabase();

			//TODO bulk insert
			OracleCommand cmd = connection.CreateCommand();
			cmd.CommandText = "INSERT INTO CRAIGSLISTITEMS (ITEM_ID, CRAIGSLIST_ITEM_ID,DESCRIPTION,ITEM_LOCATION,PRICE,SEARCH_KEY) VALUES(NEXT_ITEMSEQ_ID.nextval,:ID,:DESCRIPTION,:LOCATION,:PRICE,:KEY)";

			foreach (IItemInformation item in lstItemInfo)
			{
				cmd.Parameters.Add(new OracleParameter("ID", item.ID));
				cmd.Parameters.Add(new OracleParameter("DESCRIPTION", item.Description));
				cmd.Parameters.Add(new OracleParameter("LOCATION", item.PurchaseLocation));
				cmd.Parameters.Add(new OracleParameter("PRICE", item.Price));
				cmd.Parameters.Add(new OracleParameter("KEY", item.SearchKey));

				int rowsUpdated = cmd.ExecuteNonQuery();
				if (rowsUpdated == 0)
				{
					throw new Exception("Failed to add data to database");
				}
			}

			closeDatabase();
		}
	}
}
