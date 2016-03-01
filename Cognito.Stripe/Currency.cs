using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe
{
	public class Currency : Lookup
	{
		#region Static Instances
		public static readonly Currency AED = new Currency { Code = "AED", Name = "United Arab Emirates Dirham", NumberOfDecimals = 2, Symbol = "د.إ.‏" };
		public static readonly Currency AFN = new Currency { Code = "AFN", Name = "Afghan Afghani", NumberOfDecimals = 2, Symbol = "؋" };
		public static readonly Currency ALBL = new Currency { Code = "ALL", Name = "Albanian Lek", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency AMD = new Currency { Code = "AMD", Name = "Armenian Dram", NumberOfDecimals = 2, Symbol = "֏" };
		public static readonly Currency ANG = new Currency { Code = "ANG", Name = "Netherlands Antillean Gulden", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency AOA = new Currency { Code = "AOA", Name = "Angolan Kwanza", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency ARS = new Currency { Code = "ARS", Name = "Argentine Peso", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency AUD = new Currency { Code = "AUD", Name = "Australian Dollar", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency AWG = new Currency { Code = "AWG", Name = "Aruban Florin", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency AZN = new Currency { Code = "AZN", Name = "Azerbaijani Manat", NumberOfDecimals = 2, Symbol = "ман." };
		public static readonly Currency BAM = new Currency { Code = "BAM", Name = "Bosnia & Herzegovina Convertible Mark", NumberOfDecimals = 2, Symbol = "КМ" };
		public static readonly Currency BBD = new Currency { Code = "BBD", Name = "Barbadian Dollar", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency BDT = new Currency { Code = "BDT", Name = "Bangladeshi Taka", NumberOfDecimals = 2, Symbol = "৳" };
		public static readonly Currency BGN = new Currency { Code = "BGN", Name = "Bulgarian Lev", NumberOfDecimals = 2, Symbol = "лв." };
		public static readonly Currency BIF = new Currency { Code = "BIF", Name = "Burundian Franc", NumberOfDecimals = 0, Symbol = "$" };
		public static readonly Currency BMD = new Currency { Code = "BMD", Name = "Bermudian Dollar", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency BND = new Currency { Code = "BND", Name = "Brunei Dollar", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency BOB = new Currency { Code = "BOB", Name = "Bolivian Boliviano", NumberOfDecimals = 2, Symbol = "Bs." };
		public static readonly Currency BRL = new Currency { Code = "BRL", Name = "Brazilian Real", NumberOfDecimals = 2, Symbol = "R$" };
		public static readonly Currency BSD = new Currency { Code = "BSD", Name = "Bahamian Dollar", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency BWP = new Currency { Code = "BWP", Name = "Botswana Pula", NumberOfDecimals = 2, Symbol = "P" };
		public static readonly Currency BZD = new Currency { Code = "BZD", Name = "Belize Dollar", NumberOfDecimals = 2, Symbol = "BZ$" };
		public static readonly Currency CAD = new Currency { Code = "CAD", Name = "Canadian Dollar", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency CDF = new Currency { Code = "CDF", Name = "Congolese Franc", NumberOfDecimals = 2, Symbol = "FC" };
		public static readonly Currency CHF = new Currency { Code = "CHF", Name = "Swiss Franc", NumberOfDecimals = 2, Symbol = "Fr." };
		public static readonly Currency CLP = new Currency { Code = "CLP", Name = "Chilean Peso", NumberOfDecimals = 0, Symbol = "$" };
		public static readonly Currency CNY = new Currency { Code = "CNY", Name = "Chinese Renminbi Yuan", NumberOfDecimals = 2, Symbol = "¥" };
		public static readonly Currency COP = new Currency { Code = "COP", Name = "Colombian Peso", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency CRC = new Currency { Code = "CRC", Name = "Costa Rican Colón", NumberOfDecimals = 2, Symbol = "₡" };
		public static readonly Currency CVE = new Currency { Code = "CVE", Name = "Cape Verdean Escudo", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency CZK = new Currency { Code = "CZK", Name = "Czech Koruna", NumberOfDecimals = 2, Symbol = "Kč" };
		public static readonly Currency DJF = new Currency { Code = "DJF", Name = "Djiboutian Franc", NumberOfDecimals = 0, Symbol = "$" };
		public static readonly Currency DKK = new Currency { Code = "DKK", Name = "Danish Krone", NumberOfDecimals = 2, Symbol = "kr." };
		public static readonly Currency DOP = new Currency { Code = "DOP", Name = "Dominican Peso", NumberOfDecimals = 2, Symbol = "RD$" };
		public static readonly Currency DZD = new Currency { Code = "DZD", Name = "Algerian Dinar", NumberOfDecimals = 2, Symbol = "د.ج.‏" };
		public static readonly Currency EEK = new Currency { Code = "EEK", Name = "Estonian Kroon", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency EGP = new Currency { Code = "EGP", Name = "Egyptian Pound", NumberOfDecimals = 2, Symbol = "ج.م.‏" };
		public static readonly Currency ETB = new Currency { Code = "ETB", Name = "Ethiopian Birr", NumberOfDecimals = 2, Symbol = "ETB" };
		public static readonly Currency EUR = new Currency { Code = "EUR", Name = "Euro", NumberOfDecimals = 2, Symbol = "€" };
		public static readonly Currency FJD = new Currency { Code = "FJD", Name = "Fijian Dollar", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency FKP = new Currency { Code = "FKP", Name = "Falkland Islands Pound", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency GBP = new Currency { Code = "GBP", Name = "British Pound", NumberOfDecimals = 2, Symbol = "£" };
		public static readonly Currency GEL = new Currency { Code = "GEL", Name = "Georgian Lari", NumberOfDecimals = 2, Symbol = "ლ." };
		public static readonly Currency GIP = new Currency { Code = "GIP", Name = "Gibraltar Pound", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency GMD = new Currency { Code = "GMD", Name = "Gambian Dalasi", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency GNF = new Currency { Code = "GNF", Name = "Guinean Franc", NumberOfDecimals = 0, Symbol = "$" };
		public static readonly Currency GTQ = new Currency { Code = "GTQ", Name = "Guatemalan Quetzal", NumberOfDecimals = 2, Symbol = "Q" };
		public static readonly Currency GYD = new Currency { Code = "GYD", Name = "Guyanese Dollar", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency HKD = new Currency { Code = "HKD", Name = "Hong Kong Dollar", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency HNL = new Currency { Code = "HNL", Name = "Honduran Lempira", NumberOfDecimals = 2, Symbol = "L." };
		public static readonly Currency HRK = new Currency { Code = "HRK", Name = "Croatian Kuna", NumberOfDecimals = 2, Symbol = "kn" };
		public static readonly Currency HTG = new Currency { Code = "HTG", Name = "Haitian Gourde", NumberOfDecimals = 2, Symbol = "G" };
		public static readonly Currency HUF = new Currency { Code = "HUF", Name = "Hungarian Forint", NumberOfDecimals = 2, Symbol = "Ft" };
		public static readonly Currency IDR = new Currency { Code = "IDR", Name = "Indonesian Rupiah", NumberOfDecimals = 2, Symbol = "Rp" };
		public static readonly Currency ILS = new Currency { Code = "ILS", Name = "Israeli New Sheqel", NumberOfDecimals = 2, Symbol = "₪" };
		public static readonly Currency INR = new Currency { Code = "INR", Name = "Indian Rupee", NumberOfDecimals = 2, Symbol = "₹" };
		public static readonly Currency ISK = new Currency { Code = "ISK", Name = "Icelandic Króna", NumberOfDecimals = 2, Symbol = "kr." };
		public static readonly Currency JMD = new Currency { Code = "JMD", Name = "Jamaican Dollar", NumberOfDecimals = 2, Symbol = "J$" };
		public static readonly Currency JPY = new Currency { Code = "JPY", Name = "Japanese Yen", NumberOfDecimals = 0, Symbol = "¥" };
		public static readonly Currency KES = new Currency { Code = "KES", Name = "Kenyan Shilling", NumberOfDecimals = 2, Symbol = "KSh" };
		public static readonly Currency KGS = new Currency { Code = "KGS", Name = "Kyrgyzstani Som", NumberOfDecimals = 2, Symbol = "сом" };
		public static readonly Currency KHR = new Currency { Code = "KHR", Name = "Cambodian Riel", NumberOfDecimals = 2, Symbol = "៛" };
		public static readonly Currency KMF = new Currency { Code = "KMF", Name = "Comorian Franc", NumberOfDecimals = 0, Symbol = "$" };
		public static readonly Currency KRW = new Currency { Code = "KRW", Name = "South Korean Won", NumberOfDecimals = 0, Symbol = "₩" };
		public static readonly Currency KYD = new Currency { Code = "KYD", Name = "Cayman Islands Dollar", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency KZT = new Currency { Code = "KZT", Name = "Kazakhstani Tenge", NumberOfDecimals = 2, Symbol = "₸" };
		public static readonly Currency LAK = new Currency { Code = "LAK", Name = "Lao Kip", NumberOfDecimals = 2, Symbol = "₭" };
		public static readonly Currency LBP = new Currency { Code = "LBP", Name = "Lebanese Pound", NumberOfDecimals = 2, Symbol = "ل.ل.‏‏" };
		public static readonly Currency LKR = new Currency { Code = "LKR", Name = "Sri Lankan Rupee", NumberOfDecimals = 2, Symbol = "රු." };
		public static readonly Currency LRD = new Currency { Code = "LRD", Name = "Liberian Dollar", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency LSL = new Currency { Code = "LSL", Name = "Lesotho Loti", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency LTL = new Currency { Code = "LTL", Name = "Lithuanian Litas", NumberOfDecimals = 2, Symbol = "Lt" };
		public static readonly Currency LVL = new Currency { Code = "LVL", Name = "Latvian Lats", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency MAD = new Currency { Code = "MAD", Name = "Moroccan Dirham", NumberOfDecimals = 2, Symbol = "د.م.‏‏" };
		public static readonly Currency MDL = new Currency { Code = "MDL", Name = "Moldovan Leu", NumberOfDecimals = 2, Symbol = "L" };
		public static readonly Currency MGA = new Currency { Code = "MGA", Name = "Malagasy Ariary", NumberOfDecimals = 0, Symbol = "$" };
		public static readonly Currency MKD = new Currency { Code = "MKD", Name = "Macedonian Denar", NumberOfDecimals = 2, Symbol = "ден." };
		public static readonly Currency MNT = new Currency { Code = "MNT", Name = "Mongolian Tögrög", NumberOfDecimals = 2, Symbol = "₮" };
		public static readonly Currency MOP = new Currency { Code = "MOP", Name = "Macanese Pataca", NumberOfDecimals = 2, Symbol = "MOP" };
		public static readonly Currency MRO = new Currency { Code = "MRO", Name = "Mauritanian Ouguiya", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency MUR = new Currency { Code = "MUR", Name = "Mauritian Rupee", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency MVR = new Currency { Code = "MVR", Name = "Maldivian Rufiyaa", NumberOfDecimals = 2, Symbol = "ރ." };
		public static readonly Currency MWK = new Currency { Code = "MWK", Name = "Malawian Kwacha", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency MXN = new Currency { Code = "MXN", Name = "Mexican Peso", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency MYR = new Currency { Code = "MYR", Name = "Malaysian Ringgit", NumberOfDecimals = 2, Symbol = "RM" };
		public static readonly Currency MZN = new Currency { Code = "MZN", Name = "Mozambican Metical", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency NAD = new Currency { Code = "NAD", Name = "Namibian Dollar", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency NGN = new Currency { Code = "NGN", Name = "Nigerian Naira", NumberOfDecimals = 2, Symbol = "₦" };
		public static readonly Currency NIO = new Currency { Code = "NIO", Name = "Nicaraguan Córdoba", NumberOfDecimals = 2, Symbol = "C$" };
		public static readonly Currency NOK = new Currency { Code = "NOK", Name = "Norwegian Krone", NumberOfDecimals = 2, Symbol = "kr" };
		public static readonly Currency NPR = new Currency { Code = "NPR", Name = "Nepalese Rupee", NumberOfDecimals = 2, Symbol = "रु" };
		public static readonly Currency NZD = new Currency { Code = "NZD", Name = "New Zealand Dollar", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency PAB = new Currency { Code = "PAB", Name = "Panamanian Balboa", NumberOfDecimals = 2, Symbol = "B/." };
		public static readonly Currency PEN = new Currency { Code = "PEN", Name = "Peruvian Nuevo Sol", NumberOfDecimals = 2, Symbol = "S/." };
		public static readonly Currency PGK = new Currency { Code = "PGK", Name = "Papua New Guinean Kina", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency PHP = new Currency { Code = "PHP", Name = "Philippine Peso", NumberOfDecimals = 2, Symbol = "₱" };
		public static readonly Currency PKR = new Currency { Code = "PKR", Name = "Pakistani Rupee", NumberOfDecimals = 2, Symbol = "Rs" };
		public static readonly Currency PLN = new Currency { Code = "PLN", Name = "Polish Złoty", NumberOfDecimals = 2, Symbol = "zł" };
		public static readonly Currency PYG = new Currency { Code = "PYG", Name = "Paraguayan Guaraní", NumberOfDecimals = 0, Symbol = "₲" };
		public static readonly Currency QAR = new Currency { Code = "QAR", Name = "Qatari Riyal", NumberOfDecimals = 2, Symbol = "ر.ق.‏‏" };
		public static readonly Currency RON = new Currency { Code = "RON", Name = "Romanian Leu", NumberOfDecimals = 2, Symbol = "lei" };
		public static readonly Currency RSD = new Currency { Code = "RSD", Name = "Serbian Dinar", NumberOfDecimals = 2, Symbol = "дин." };
		public static readonly Currency RUB = new Currency { Code = "RUB", Name = "Russian Ruble", NumberOfDecimals = 2, Symbol = "₽" };
		public static readonly Currency RWF = new Currency { Code = "RWF", Name = "Rwandan Franc", NumberOfDecimals = 0, Symbol = "RWF" };
		public static readonly Currency SAR = new Currency { Code = "SAR", Name = "Saudi Riyal", NumberOfDecimals = 2, Symbol = "ر.س.‏" };
		public static readonly Currency SBD = new Currency { Code = "SBD", Name = "Solomon Islands Dollar", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency SCR = new Currency { Code = "SCR", Name = "Seychellois Rupee", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency SEK = new Currency { Code = "SEK", Name = "Swedish Krona", NumberOfDecimals = 2, Symbol = "kr" };
		public static readonly Currency SGD = new Currency { Code = "SGD", Name = "Singapore Dollar", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency SHP = new Currency { Code = "SHP", Name = "Saint Helenian Pound", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency SLL = new Currency { Code = "SLL", Name = "Sierra Leonean Leone", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency SOS = new Currency { Code = "SOS", Name = "Somali Shilling", NumberOfDecimals = 2, Symbol = "S" };
		public static readonly Currency SRD = new Currency { Code = "SRD", Name = "Surinamese Dollar", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency STD = new Currency { Code = "STD", Name = "São Tomé and Príncipe Dobra", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency SVC = new Currency { Code = "SVC", Name = "Salvadoran Colón", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency SZL = new Currency { Code = "SZL", Name = "Swazi Lilangeni", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency THB = new Currency { Code = "THB", Name = "Thai Baht", NumberOfDecimals = 2, Symbol = "฿" };
		public static readonly Currency TJS = new Currency { Code = "TJS", Name = "Tajikistani Somoni", NumberOfDecimals = 2, Symbol = "смн" };
		public static readonly Currency TOP = new Currency { Code = "TOP", Name = "Tongan Paʻanga", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency TRY = new Currency { Code = "TRY", Name = "Turkish Lira", NumberOfDecimals = 2, Symbol = "₺" };
		public static readonly Currency TTD = new Currency { Code = "TTD", Name = "Trinidad and Tobago Dollar", NumberOfDecimals = 2, Symbol = "TT$" };
		public static readonly Currency TWD = new Currency { Code = "TWD", Name = "New Taiwan Dollar", NumberOfDecimals = 2, Symbol = "NT$" };
		public static readonly Currency TZS = new Currency { Code = "TZS", Name = "Tanzanian Shilling", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency UAH = new Currency { Code = "UAH", Name = "Ukrainian Hryvnia", NumberOfDecimals = 2, Symbol = "₴" };
		public static readonly Currency UGX = new Currency { Code = "UGX", Name = "Ugandan Shilling", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency USD = new Currency { Code = "USD", Name = "United States Dollar", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency UYU = new Currency { Code = "UYU", Name = "Uruguayan Peso", NumberOfDecimals = 2, Symbol = "$U" };
		public static readonly Currency UZS = new Currency { Code = "UZS", Name = "Uzbekistani Som", NumberOfDecimals = 2, Symbol = "сўм" };
		public static readonly Currency VND = new Currency { Code = "VND", Name = "Vietnamese Đồng", NumberOfDecimals = 0, Symbol = "₫" };
		public static readonly Currency VUV = new Currency { Code = "VUV", Name = "Vanuatu Vatu", NumberOfDecimals = 0, Symbol = "$" };
		public static readonly Currency WST = new Currency { Code = "WST", Name = "Samoan Tala", NumberOfDecimals = 2, Symbol = "$" };
		public static readonly Currency XAF = new Currency { Code = "XAF", Name = "Central African Cfa Franc", NumberOfDecimals = 0, Symbol = "FCFA" };
		public static readonly Currency XCD = new Currency { Code = "XCD", Name = "East Caribbean Dollar", NumberOfDecimals = 2, Symbol = "EC$" };
		public static readonly Currency XOF = new Currency { Code = "XOF", Name = "West African Cfa Franc", NumberOfDecimals = 0, Symbol = "CFA" };
		public static readonly Currency XPF = new Currency { Code = "XPF", Name = "Cfp Franc", NumberOfDecimals = 0, Symbol = "$" };
		public static readonly Currency YER = new Currency { Code = "YER", Name = "Yemeni Rial", NumberOfDecimals = 2, Symbol = "ر.ي.‏‏" };
		public static readonly Currency ZAR = new Currency { Code = "ZAR", Name = "South African Rand", NumberOfDecimals = 2, Symbol = "R" };
		public static readonly Currency ZMW = new Currency { Code = "ZMW", Name = "Zambian Kwacha", NumberOfDecimals = 2, Symbol = "$" };
		#endregion

		public int NumberOfDecimals { get; set; }
		public string Symbol { get; set; }
		public override string DisplayName { get { return String.Format("{0} ({1})", Name, Symbol); } }

		public static Currency[] All { get; set; }
		public static Currency GetByCode(string code)
		{
			return All != null ? All.FirstOrDefault(l => l.Code.ToUpper() == code.ToUpper()) : null;
		}

		static Currency()
		{
			All = new Currency[]
			{ 
				AED, AFN, ALBL, AMD, ANG, AOA, ARS, AUD, AWG, AZN, BAM, BBD, BDT, BGN, BIF, BMD, BND, BOB, BRL, BSD, BWP, BZD, CAD, CDF, CHF, 
				CLP, CNY, COP, CRC, CVE, CZK, DJF, DKK, DOP, DZD, EEK, EGP, ETB, EUR, FJD, FKP, GBP, GEL, GIP, GMD, GNF, GTQ, GYD, HKD, HNL, 
				HRK, HTG, HUF, IDR, ILS, INR, ISK, JMD, JPY, KES, KGS, KHR, KMF, KRW, KYD, KZT, LAK, LBP, LKR, LRD, LSL, LTL, LVL, MAD, MDL, 
				MGA, MKD, MNT, MOP, MRO, MUR, MVR, MWK, MXN, MYR, MZN, NAD, NGN, NIO, NOK, NPR, NZD, PAB, PEN, PGK, PHP, PKR, PLN, PYG, QAR, 
				RON, RSD, RUB, RWF, SAR, SBD, SCR, SEK, SGD, SHP, SLL, SOS, SRD, STD, SVC, SZL, THB, TJS, TOP, TRY, TTD, TWD, TZS, UAH, UGX, 
				USD, UYU, UZS, VND, VUV, WST, XAF, XCD, XOF, XPF, YER, ZAR, ZMW 
			};
		}
	}
}
