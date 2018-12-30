using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
	}
}
