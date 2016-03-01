using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe
{
	public class Country : Lookup
	{
		#region Static Instances
		public static readonly Country UnitedArabEmirates = new Country { Code = "AE", Name = "United Arab Emirates", Currency = Currency.AED };
		public static readonly Country Afghanistan = new Country { Code = "AF", Name = "Afghanistan", Currency = Currency.AFN };
		public static readonly Country Albania = new Country { Code = "AL", Name = "Albania", Currency = Currency.ALBL };
		public static readonly Country Armenia = new Country { Code = "AM", Name = "Armenia", Currency = Currency.AMD };
		public static readonly Country Argentina = new Country { Code = "AR", Name = "Argentina", Currency = Currency.ARS };
		public static readonly Country Austria = new Country { Code = "AT", Name = "Austria", Currency = Currency.EUR };
		public static readonly Country Australia = new Country { Code = "AU", Name = "Australia", Currency = Currency.AUD };
		public static readonly Country Azerbaijan = new Country { Code = "AZ", Name = "Azerbaijan", Currency = Currency.AZN };
		public static readonly Country BosniaAndHerzegovina = new Country { Code = "BA", Name = "Bosnia and Herzegovina", Currency = Currency.BAM };
		public static readonly Country Bangladesh = new Country { Code = "BD", Name = "Bangladesh", Currency = Currency.BDT };
		public static readonly Country Belgium = new Country { Code = "BE", Name = "Belgium", Currency = Currency.EUR };
		public static readonly Country Bulgaria = new Country { Code = "BG", Name = "Bulgaria", Currency = Currency.BGN };
		public static readonly Country Brunei = new Country { Code = "BN", Name = "Brunei", Currency = Currency.BND };
		public static readonly Country Bolivia = new Country { Code = "BO", Name = "Bolivia", Currency = Currency.BOB };
		public static readonly Country Brazil = new Country { Code = "BR", Name = "Brazil", Currency = Currency.BRL };
		public static readonly Country Botswana = new Country { Code = "BW", Name = "Botswana", Currency = Currency.BWP };
		public static readonly Country Belize = new Country { Code = "BZ", Name = "Belize", Currency = Currency.BZD };
		public static readonly Country Canada = new Country { Code = "CA", Name = "Canada", Currency = Currency.CAD };
		public static readonly Country Congo = new Country { Code = "CD", Name = "Congo", Currency = Currency.CDF };
		public static readonly Country Switzerland = new Country { Code = "CH", Name = "Switzerland", Currency = Currency.CHF };
		public static readonly Country IvoryCoast = new Country { Code = "CI", Name = "Ivory Coast", Currency = Currency.XOF };
		public static readonly Country Chile = new Country { Code = "CL", Name = "Chile", Currency = Currency.CLP };
		public static readonly Country Cameroon = new Country { Code = "CM", Name = "Cameroon", Currency = Currency.XAF };
		public static readonly Country China = new Country { Code = "CN", Name = "China", Currency = Currency.CNY };
		public static readonly Country Colombia = new Country { Code = "CO", Name = "Colombia", Currency = Currency.COP };
		public static readonly Country CostaRica = new Country { Code = "CR", Name = "Costa Rica", Currency = Currency.CRC };
		public static readonly Country CzechRepublic = new Country { Code = "CZ", Name = "Czech Republic", Currency = Currency.CZK };
		public static readonly Country Germany = new Country { Code = "DE", Name = "Germany", Currency = Currency.EUR };
		public static readonly Country Denmark = new Country { Code = "DK", Name = "Denmark", Currency = Currency.DKK };
		public static readonly Country DominicanRepublic = new Country { Code = "DO", Name = "Dominican Republic", Currency = Currency.DOP };
		public static readonly Country Algeria = new Country { Code = "DZ", Name = "Algeria", Currency = Currency.DZD };
		public static readonly Country Ecuador = new Country { Code = "EC", Name = "Ecuador", Currency = Currency.USD };
		public static readonly Country Estonia = new Country { Code = "EE", Name = "Estonia", Currency = Currency.EUR };
		public static readonly Country Egypt = new Country { Code = "EG", Name = "Egypt", Currency = Currency.EGP };
		public static readonly Country Spain = new Country { Code = "ES", Name = "Spain", Currency = Currency.EUR };
		public static readonly Country Ethiopia = new Country { Code = "ET", Name = "Ethiopia", Currency = Currency.ETB };
		public static readonly Country Finland = new Country { Code = "FI", Name = "Finland", Currency = Currency.EUR };
		public static readonly Country FaroeIslands = new Country { Code = "FO", Name = "Faroe Islands", Currency = Currency.DKK };
		public static readonly Country France = new Country { Code = "FR", Name = "France", Currency = Currency.EUR };
		public static readonly Country UnitedKingdom = new Country { Code = "GB", Name = "United Kingdom", Currency = Currency.GBP };
		public static readonly Country Georgia = new Country { Code = "GE", Name = "Georgia", Currency = Currency.GEL };
		public static readonly Country Greenland = new Country { Code = "GL", Name = "Greenland", Currency = Currency.DKK };
		public static readonly Country Greece = new Country { Code = "GR", Name = "Greece", Currency = Currency.EUR };
		public static readonly Country Guatemala = new Country { Code = "GT", Name = "Guatemala", Currency = Currency.GTQ };
		public static readonly Country HongKong = new Country { Code = "HK", Name = "Hong Kong", Currency = Currency.HKD };
		public static readonly Country Honduras = new Country { Code = "HN", Name = "Honduras", Currency = Currency.HNL };
		public static readonly Country Croatia = new Country { Code = "HR", Name = "Croatia", Currency = Currency.HRK };
		public static readonly Country Haiti = new Country { Code = "HT", Name = "Haiti", Currency = Currency.HTG };
		public static readonly Country Hungary = new Country { Code = "HU", Name = "Hungary", Currency = Currency.HUF };
		public static readonly Country Indonesia = new Country { Code = "ID", Name = "Indonesia", Currency = Currency.IDR };
		public static readonly Country Ireland = new Country { Code = "IE", Name = "Ireland", Currency = Currency.EUR };
		public static readonly Country Israel = new Country { Code = "IL", Name = "Israel", Currency = Currency.ILS };
		public static readonly Country India = new Country { Code = "IN", Name = "India", Currency = Currency.INR };
		public static readonly Country Iceland = new Country { Code = "IS", Name = "Iceland", Currency = Currency.ISK };
		public static readonly Country Italy = new Country { Code = "IT", Name = "Italy", Currency = Currency.EUR };
		public static readonly Country Jamaica = new Country { Code = "JM", Name = "Jamaica", Currency = Currency.JMD };
		public static readonly Country Japan = new Country { Code = "JP", Name = "Japan", Currency = Currency.JPY };
		public static readonly Country Kenya = new Country { Code = "KE", Name = "Kenya", Currency = Currency.KES };
		public static readonly Country Kyrgyzstan = new Country { Code = "KG", Name = "Kyrgyzstan", Currency = Currency.KGS };
		public static readonly Country Cambodia = new Country { Code = "KH", Name = "Cambodia", Currency = Currency.KHR };
		public static readonly Country Korea = new Country { Code = "KR", Name = "Korea", Currency = Currency.KRW };
		public static readonly Country Kazakhstan = new Country { Code = "KZ", Name = "Kazakhstan", Currency = Currency.KZT };
		public static readonly Country Lao = new Country { Code = "LA", Name = "Lao", Currency = Currency.LAK };
		public static readonly Country Lebanon = new Country { Code = "LB", Name = "Lebanon", Currency = Currency.LBP };
		public static readonly Country Liechtenstein = new Country { Code = "LI", Name = "Liechtenstein", Currency = Currency.CHF };
		public static readonly Country SriLanka = new Country { Code = "LK", Name = "Sri Lanka", Currency = Currency.LKR };
		public static readonly Country Lithuania = new Country { Code = "LT", Name = "Lithuania", Currency = Currency.LTL };
		public static readonly Country Luxembourg = new Country { Code = "LU", Name = "Luxembourg", Currency = Currency.EUR };
		public static readonly Country Latvia = new Country { Code = "LV", Name = "Latvia", Currency = Currency.EUR };
		public static readonly Country Morocco = new Country { Code = "MA", Name = "Morocco", Currency = Currency.MAD };
		public static readonly Country Monaco = new Country { Code = "MC", Name = "Monaco", Currency = Currency.EUR };
		public static readonly Country Moldova = new Country { Code = "MD", Name = "Moldova", Currency = Currency.MDL };
		public static readonly Country Montenegro = new Country { Code = "ME", Name = "Montenegro", Currency = Currency.EUR };
		public static readonly Country Macedonia = new Country { Code = "MK", Name = "Macedonia", Currency = Currency.MKD };
		public static readonly Country Mali = new Country { Code = "ML", Name = "Mali", Currency = Currency.XOF };
		public static readonly Country Mongolia = new Country { Code = "MN", Name = "Mongolia", Currency = Currency.MNT };
		public static readonly Country Macao = new Country { Code = "MO", Name = "Macao", Currency = Currency.MOP };
		public static readonly Country Malta = new Country { Code = "MT", Name = "Malta", Currency = Currency.EUR };
		public static readonly Country Maldives = new Country { Code = "MV", Name = "Maldives", Currency = Currency.MVR };
		public static readonly Country Mexico = new Country { Code = "MX", Name = "Mexico", Currency = Currency.MXN };
		public static readonly Country Malaysia = new Country { Code = "MY", Name = "Malaysia", Currency = Currency.MYR };
		public static readonly Country Nigeria = new Country { Code = "NG", Name = "Nigeria", Currency = Currency.NGN };
		public static readonly Country Nicaragua = new Country { Code = "NI", Name = "Nicaragua", Currency = Currency.NIO };
		public static readonly Country Netherlands = new Country { Code = "NL", Name = "Netherlands", Currency = Currency.EUR };
		public static readonly Country Norway = new Country { Code = "NO", Name = "Norway", Currency = Currency.NOK };
		public static readonly Country Nepal = new Country { Code = "NP", Name = "Nepal", Currency = Currency.NPR };
		public static readonly Country NewZealand = new Country { Code = "NZ", Name = "New Zealand", Currency = Currency.NZD };
		public static readonly Country Panama = new Country { Code = "PA", Name = "Panama", Currency = Currency.PAB };
		public static readonly Country Peru = new Country { Code = "PE", Name = "Peru", Currency = Currency.PEN };
		public static readonly Country Philippines = new Country { Code = "PH", Name = "Philippines", Currency = Currency.PHP };
		public static readonly Country Pakistan = new Country { Code = "PK", Name = "Pakistan", Currency = Currency.PKR };
		public static readonly Country Poland = new Country { Code = "PL", Name = "Poland", Currency = Currency.PLN };
		public static readonly Country PuertoRico = new Country { Code = "PR", Name = "Puerto Rico", Currency = Currency.USD };
		public static readonly Country Portugal = new Country { Code = "PT", Name = "Portugal", Currency = Currency.EUR };
		public static readonly Country Paraguay = new Country { Code = "PY", Name = "Paraguay", Currency = Currency.PYG };
		public static readonly Country Qatar = new Country { Code = "QA", Name = "Qatar", Currency = Currency.QAR };
		public static readonly Country Réunion = new Country { Code = "RE", Name = "Réunion", Currency = Currency.EUR };
		public static readonly Country Romania = new Country { Code = "RO", Name = "Romania", Currency = Currency.RON };
		public static readonly Country Serbia = new Country { Code = "RS", Name = "Serbia", Currency = Currency.RSD };
		public static readonly Country Russia = new Country { Code = "RU", Name = "Russia", Currency = Currency.RUB };
		public static readonly Country Rwanda = new Country { Code = "RW", Name = "Rwanda", Currency = Currency.RWF };
		public static readonly Country SaudiArabia = new Country { Code = "SA", Name = "Saudi Arabia", Currency = Currency.SAR };
		public static readonly Country Sweden = new Country { Code = "SE", Name = "Sweden", Currency = Currency.SEK };
		public static readonly Country Singapore = new Country { Code = "SG", Name = "Singapore", Currency = Currency.SGD };
		public static readonly Country Slovenia = new Country { Code = "SI", Name = "Slovenia", Currency = Currency.EUR };
		public static readonly Country Slovakia = new Country { Code = "SK", Name = "Slovakia", Currency = Currency.EUR };
		public static readonly Country Senegal = new Country { Code = "SN", Name = "Senegal", Currency = Currency.XOF };
		public static readonly Country Somalia = new Country { Code = "SO", Name = "Somalia", Currency = Currency.SOS };
		public static readonly Country ElSalvador = new Country { Code = "SV", Name = "El Salvador", Currency = Currency.USD };
		public static readonly Country Thailand = new Country { Code = "TH", Name = "Thailand", Currency = Currency.THB };
		public static readonly Country Tajikistan = new Country { Code = "TJ", Name = "Tajikistan", Currency = Currency.TJS };
		public static readonly Country Turkey = new Country { Code = "TR", Name = "Turkey", Currency = Currency.TRY };
		public static readonly Country TrinidadAndTobago = new Country { Code = "TT", Name = "Trinidad and Tobago", Currency = Currency.TTD };
		public static readonly Country Taiwan = new Country { Code = "TW", Name = "Taiwan", Currency = Currency.TWD };
		public static readonly Country Ukraine = new Country { Code = "UA", Name = "Ukraine", Currency = Currency.UAH };
		public static readonly Country UnitedStates = new Country { Code = "US", Name = "United States", Currency = Currency.USD };
		public static readonly Country Uruguay = new Country { Code = "UY", Name = "Uruguay", Currency = Currency.UYU };
		public static readonly Country Uzbekistan = new Country { Code = "UZ", Name = "Uzbekistan", Currency = Currency.UZS };
		public static readonly Country Vietnam = new Country { Code = "VN", Name = "Vietnam", Currency = Currency.VND };
		public static readonly Country Yemen = new Country { Code = "YE", Name = "Yemen", Currency = Currency.YER };
		public static readonly Country SouthAfrica = new Country { Code = "ZA", Name = "South Africa", Currency = Currency.ZAR };
		public static readonly Country SerbiaAndMontenegro = new Country { Code = "CS", Name = "Serbia and Montenegro", Currency = Currency.RSD };
		#endregion

		public static Country[] All { get; set; }
		public static Country GetByCode(string code)
		{
			return All != null ? All.FirstOrDefault(l => l.Code == code) : null;
		}

		static Country()
		{
			All = new Country[] 
			{ 
				Afghanistan, Albania, Algeria, Argentina, Armenia, Australia, Austria, Azerbaijan, Bangladesh, Belgium, Belize, Bolivia, 
				BosniaAndHerzegovina, Botswana, Brazil, Brunei, Bulgaria, Cambodia,  Cameroon,  Canada, Chile, China,  Colombia, Congo, 
				CostaRica, Croatia, CzechRepublic, Denmark, DominicanRepublic, Ecuador, Egypt, ElSalvador, Estonia, Ethiopia, FaroeIslands, 
				Finland,  France, Georgia, Germany, Greece, Greenland, Guatemala, Haiti, Honduras,  HongKong, Hungary, Iceland, India, 
				Indonesia, Ireland, Israel, Italy, IvoryCoast, Jamaica, Japan, Kazakhstan, Kenya, Korea, Kyrgyzstan, Lao, Latvia, Lebanon, 
				Liechtenstein, Lithuania, Luxembourg, Macao, Macedonia, Malaysia, Maldives, Mali, Malta,  Mexico, Moldova,  Monaco, Mongolia, 
				Montenegro, Morocco, Nepal, Netherlands, NewZealand, Nicaragua, Nigeria, Norway, Pakistan, Panama, Paraguay, Peru, Philippines, 
				Poland, Portugal, PuertoRico, Qatar, Réunion, Romania, Russia,  Rwanda, SaudiArabia, Senegal, Serbia, SerbiaAndMontenegro, Singapore, 
				Slovakia, Slovenia, Somalia, SouthAfrica, Spain, SriLanka, Sweden, Switzerland, Taiwan, Tajikistan, Thailand, TrinidadAndTobago, Turkey, 
				Ukraine, UnitedArabEmirates, UnitedKingdom, UnitedStates, Uruguay, Uzbekistan, Vietnam, Yemen
			};
		}

		public Currency Currency { get; set; }
	}
}
