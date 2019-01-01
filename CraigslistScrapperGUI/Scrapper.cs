using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataHandler.Enums;
using WebScrapper;
using System.Diagnostics;

namespace CraigslistScrapper
{
	public partial class frmScrapper : Form
	{
		public frmScrapper()
		{
			InitializeComponent();
			fillCategories();
			fillConditions();
		}

		private void fillConditions()
		{
			Array lstEnums = Enum.GetValues(typeof(DataHandler.Enums.Enums.EnumCondition));
			foreach (Enums.EnumCondition enums in lstEnums)
			{
				chkBoxCondition.Items.Add(enums.ToString(), true);
			}
		}

		private void fillCategories()
		{
			Array lstEnums = Enum.GetValues(typeof(DataHandler.Enums.Enums.EnumCategory));
			foreach (Enums.EnumCategory enums in lstEnums)
			{
				Item itm = new Item(Enums.GetDescription(enums), enums.GetHashCode());
				ddlCategory.Items.Add(itm);
				if(itm.Value == 1)
				{
					ddlCategory.SelectedItem = itm;
				}
			}
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			//Args to pass in: State, Search, Category, Min price, Max price, Zip code, search distance, Condition
			Process p = new Process();
			using (p)
			{
				string directoryName = new System.IO.FileInfo(System.IO.Path.Combine(Application.StartupPath, @"...\...")).DirectoryName;
				p.StartInfo.FileName = directoryName + "\\WebScrapper\\bin\\Debug\\WebScrapper.exe";
				Item catItem = (Item)ddlCategory.SelectedItem;
				string arguments = String.Format("{0} {1} {2} {3} {4} {5} {6}",
					(string.IsNullOrEmpty(txtBoxCraigslistURL.Text) ? "\"\"" : txtBoxCraigslistURL.Text),
					(string.IsNullOrEmpty(txtBoxSearch.Text) ? "\"\"" : "\"" + txtBoxSearch.Text+ "\""),
					(string.IsNullOrEmpty(catItem.Value.ToString()) ? "\"\"" : catItem.Value.ToString()), 
					(string.IsNullOrEmpty(upDwnMinPrice.Value.ToString()) ? "\"\"" : upDwnMinPrice.Value.ToString()), 
					(string.IsNullOrEmpty(upDwnMaxPrice.Value.ToString()) ? "\"\"" : upDwnMaxPrice.Value.ToString()), 
					(string.IsNullOrEmpty(txtBoxZipCode.Text) ? "\"\"" : txtBoxZipCode.Text), 
					(string.IsNullOrEmpty(upDwnRadius.Value.ToString()) ? "\"\"" : upDwnRadius.Value.ToString())
				);
				foreach(string item in chkBoxCondition.CheckedItems)
				{
					Enums.EnumCondition condition;
					if(Enum.TryParse(item.ToString(), out condition))
					{
						arguments = arguments + " " + condition.GetHashCode();
					}else
					{
						arguments = arguments + "\"\"";
					}
				}
				p.StartInfo.Arguments = arguments;
				p.Start();
			}

		}
	}

	//Item class to fill drop downs
	public class Item
	{
		public string Name;
		public int Value;
		public Item(string name, int value)
		{
			Name = name; Value = value;
		}
		public override string ToString()
		{
			// Generates the text shown in the combo box
			return Name;
		}
	}
}
