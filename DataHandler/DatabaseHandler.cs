using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataHandler.Enums.Enums;

namespace DataHandler
{
	public class DatabaseHandler
	{
		private DataHandler.Interface.IDatabase iDatabase;
		public DataHandler.Interface.IDatabase database
		{
			get { return iDatabase; }
		}

		public DatabaseHandler(EnumDatabaseType dbType)
		{
			switch (dbType)
			{
				case EnumDatabaseType.CSV:
					iDatabase = new CSV();
					break;
				case EnumDatabaseType.ORACLE:
					iDatabase = new OracleDB();
					break;
			}
		} 
	}
}
