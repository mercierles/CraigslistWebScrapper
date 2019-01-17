using System;
using System.Collections.Generic;
using DataHandler.Interface;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Oracle.ManagedDataAccess.Client;
using System.Data;
using DataHandler.Databases;
using System.Diagnostics;

namespace DataHandler
{
    public class OracleDB : IDatabase
    {
		private CraigslistDataTable CDT = new CraigslistDataTable();

		private const string CONNECTIONSTRING = "User Id=system; password=Password1;Data Source=localhost:1521/DB1; Pooling=false;";

		public OracleDB(){}

		public void addItemsToTable(IItemInformation itemInfo)
		{
			CDT.AddItemsToDatatable(itemInfo);
		}

		public void addItemsToTable(List<IItemInformation> lstItemInfo)
		{
			CDT.AddItemsToDatatable(lstItemInfo);
		}

		public CraigslistDataTable getTable()
		{
			return CDT;
		}

		public void submitItemsToDatabase()
		{
			try
			{
				using (var connection = new OracleConnection(CONNECTIONSTRING))
				{
					connection.Open();
					StoreDataInTempTable(connection);
					// create command and set properties  
					OracleCommand cmd = connection.CreateCommand();
					//Merge data from temp table
					//if (!Debugger.IsAttached)
					//	Debugger.Launch();
					cmd.CommandText = "MERGE INTO CRAIGSLISTITEMS TARGET USING TEMPCRAIGSLISTITEMS SOURCE ON (TARGET.CRAIGSLIST_ITEM_ID = SOURCE.CRAIGSLIST_ITEM_ID) WHEN MATCHED THEN UPDATE SET TARGET.DESCRIPTION = SOURCE.DESCRIPTION,TARGET.ITEM_LOCATION = SOURCE.ITEM_LOCATION,TARGET.PRICE = SOURCE.PRICE,TARGET.SEARCH_KEY = SOURCE.SEARCH_KEY WHEN NOT MATCHED THEN INSERT (TARGET.ITEM_ID,TARGET.CRAIGSLIST_ITEM_ID,TARGET.DESCRIPTION,TARGET.ITEM_LOCATION,TARGET.PRICE,TARGET.SEARCH_KEY) VALUES (SOURCE.ITEM_ID,SOURCE.CRAIGSLIST_ITEM_ID,SOURCE.DESCRIPTION,SOURCE.ITEM_LOCATION,SOURCE.PRICE,SOURCE.SEARCH_KEY)";
					cmd.ExecuteNonQuery();
				}
			}catch (Exception ex){
				throw ex;
			}
		}

		public void StoreDataInTempTable(OracleConnection connection)
		{
			//if (!Debugger.IsAttached)
			//	Debugger.Launch();
			try
			{

					string[] ids = new string[CDT.Table.Rows.Count];
					string[] descriptions = new string[CDT.Table.Rows.Count];
					string[] locations = new string[CDT.Table.Rows.Count];
					double[] prices = new double[CDT.Table.Rows.Count];
					string[] keys = new string[CDT.Table.Rows.Count];

					for (int j = 0; j < CDT.Table.Rows.Count; j++)
					{
						ids[j] = Convert.ToString(CDT.Table.Rows[j]["CRAIGSLIST_ITEM_ID"]);
						descriptions[j] = Convert.ToString(CDT.Table.Rows[j]["DESCRIPTION"]);
						locations[j] = Convert.ToString(CDT.Table.Rows[j]["ITEM_LOCATION"]);
						prices[j] = Convert.ToDouble(CDT.Table.Rows[j]["PRICE"]);
						keys[j] = Convert.ToString(CDT.Table.Rows[j]["SEARCH_KEY"]);
					}

					OracleParameter id = new OracleParameter();
					id.OracleDbType = OracleDbType.Varchar2;
					id.Value = ids;

					OracleParameter name = new OracleParameter();
					name.OracleDbType = OracleDbType.Varchar2;
					name.Value = descriptions;

					OracleParameter address = new OracleParameter();
					address.OracleDbType = OracleDbType.Varchar2;
					address.Value = locations;

					OracleParameter price = new OracleParameter();
					price.OracleDbType = OracleDbType.BinaryFloat;
					price.Value = prices;

					OracleParameter key = new OracleParameter();
					key.OracleDbType = OracleDbType.Varchar2;
					key.Value = keys;

					// create command and set properties  
					OracleCommand cmd = connection.CreateCommand();

					//Add SEQ to Oracle for unique ids and call .nextval
					cmd.CommandText = "INSERT INTO TEMPCRAIGSLISTITEMS (ITEM_ID,CRAIGSLIST_ITEM_ID, DESCRIPTION, ITEM_LOCATION, PRICE, SEARCH_KEY) VALUES (NEXT_ITEMSEQ_ID.nextval,:1, :2, :3, :4, :5)";
					cmd.ArrayBindCount = ids.Length;
					cmd.Parameters.Add(id);
					cmd.Parameters.Add(name);
					cmd.Parameters.Add(address);
					cmd.Parameters.Add(price);
					cmd.Parameters.Add(key);
					cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
