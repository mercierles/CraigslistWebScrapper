using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataHandler.Enums.Enums;

namespace DataHandler.Interface
{
	public interface ISearchOptions
	{
		string URL { get; set; }
		EnumCategory Category { get; set; }
		string Search { get; set; }
		List<EnumCondition> Condition { get; set; }
		string MinPrice { get; set; }
		string MaxPrice { get; set; }
		string SearchDistance { get; set; }
		string SearchZip { get; set; }
		EnumDatabaseType DBType { get; set; }
	}
}
