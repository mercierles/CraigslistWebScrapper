using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataHandler.Enums
{
	public class Enums
	{
		public enum EnumCategory
		{
			[Description("all")]
			sss = 1,
			[Description("antiques")]
			ata = 2,
			[Description("appliances")]
			ppa = 3,
			[Description("arts+crafts")]
			ara = 4,
			[Description("atvs/utvs/snow")]
			sna = 5,
			[Description("auto parts")]
			pta = 6,
			[Description("auto wheels tires")]
			wta = 7,
			[Description("aviation")]
			ava = 8,
			[Description("baby+kids")]
			baa = 9,
			[Description("barter")]
			bar = 10,
			[Description("beauty+hlth")]
			haa = 11,
			[Description("bike parts")]
			bip = 12,
			[Description("bikes")]
			bia = 13,
			[Description("boat parts")]
			bpa = 14,
			[Description("boats")]
			boo = 15,
			[Description("books")]
			bka = 16,
			[Description("business")]
			bfa = 17,
			[Description("cars+trucks")]
			cta = 18,
			[Description("cds/dvd/vhs")]
			ema = 19,
			[Description("cell phones")]
			moa = 20,
			[Description("clothes+acc")]
			cla = 21,
			[Description("collectibles")]
			cba = 22,
			[Description("computer parts")]
			syp = 23,
			[Description("computers")]
			sya = 24,
			[Description("electronics")]
			ela = 25,
			[Description("farm+garden")]
			gra = 26,
			[Description("free stuff")]
			zip = 27,
			[Description("furniture")]
			fua = 28,
			[Description("garage sales")]
			gms = 29,
			[Description("general")]
			foa = 30,
			[Description("heavy equipment")]
			hva = 31,
			[Description("household")]
			hsa = 32,
			[Description("jewelry")]
			jwa = 33,
			[Description("materials")]
			maa = 34,
			[Description("motorcycle parts")]
			mpa = 35,
			[Description("motorcycles")]
			mca = 36,
			[Description("music instr")]
			msa = 37,
			[Description("photo+video")]
			pha = 38,
			[Description("RVs")]
			rva = 39,
			[Description("sporting")]
			sga = 40,
			[Description("tickets")]
			tia = 41,
			[Description("tools")]
			tla = 42,
			[Description("toys+games")]
			taa = 43,
			[Description("trailers")]
			tra = 44,
			[Description("video gaming")]
			vga = 45,
			[Description("wanted")]
			waa = 46
		}

		public enum EnumCondition
		{
			[Description("New")]
					brandnew = 10,
			[Description("Like New")]
					likenew = 20,
			[Description("Excellent")]
					excellent = 30,
			[Description("Good")]
					good = 40,
			[Description("Fair")]
					fair = 50,
			[Description("Salvage")]
					salvage = 60
		}

		public enum EnumStates
		{
			[Description("Alabama")]
			AL = 1,
			[Description("Alaska")]
			AK = 2,
			[Description("Arizona")]
			AZ = 3,
			[Description("Arkansas")]
			AR = 4,
			[Description("California")]
			CA = 5,
			[Description("Colorado")]
			CO = 6,
			[Description("Connecticut")]
			CT = 7,
			[Description("Delaware")]
			DE = 8,
			[Description("Florida")]
			FL = 9,
			[Description("Georgia")]
			GA = 10,
			[Description("Hawaii")]
			HI = 11,
			[Description("Idaho")]
			ID = 12,
			[Description("Illinois")]
			IL = 13,
			[Description("Indiana")]
			IN = 14,
			[Description("Iowa")]
			IA = 15,
			[Description("Kansas")]
			KS = 16,
			[Description("Kentucky")]
			KY = 17,
			[Description("Louisiana")]
			LA = 18,
			[Description("Maine")]
			ME = 19,
			[Description("Maryland")]
			MD = 20,
			[Description("Massachusetts")]
			MA = 21,
			[Description("Michigan")]
			MI = 22,
			[Description("Minnesota")]
			MN = 23,
			[Description("Mississippi")]
			MS = 24,
			[Description("Missouri")]
			MO = 25,
			[Description("Montana")]
			MT = 26,
			[Description("Nebraska")]
			NE = 27,
			[Description("Nevada")]
			NV = 28,
			[Description("New Hampshire")]
			NH = 29,
			[Description("New Jersey")]
			NJ = 30,
			[Description("New Mexico")]
			NM = 31,
			[Description("New York")]
			NY = 32,
			[Description("North Carolina")]
			NC = 33,
			[Description("North Dakota")]
			ND = 34,
			[Description("Ohio")]
			OH = 35,
			[Description("Oklahoma")]
			OK = 36,
			[Description("Oregon")]
			OR = 37,
			[Description("Pennsylvania")]
			PA = 38,
			[Description("Rhode Island")]
			RI = 39,
			[Description("South Carolina")]
			SC = 40,
			[Description("South Dakota")]
			SD = 41,
			[Description("Tennessee")]
			TN = 42,
			[Description("Texas")]
			TX = 43,
			[Description("Utah")]
			UT = 44,
			[Description("Vermont")]
			VT = 45,
			[Description("Virginia")]
			VA = 46,
			[Description("Washington")]
			WA = 47,
			[Description("West Virginia")]
			WV = 48,
			[Description("Wisconsin")]
			WI = 49,
			[Description("Wyoming")]
			WY = 50
		}

		public enum EnumDatabaseType
		{
			[Description("Comma Seperated File")]
			CSV = 1,
			[Description("Oracle Database")]
			ORACLE = 2
		}
		//Code to get description courtesy of https://codereview.stackexchange.com/questions/157871/method-that-returns-description-attribute-of-enum-value
		public static string GetDescription(Enum value)
		{
			return
				value
					.GetType()
					.GetMember(value.ToString())
					.FirstOrDefault()
					?.GetCustomAttribute<DescriptionAttribute>()
					?.Description;
		}
	}
}
