using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.Stripe.Classes
{
	public class FileUpload : BaseObject
	{
		public override string Object { get { return "file_upload"; } }

		public string Purpose { get; set; }
		public int Size { get; set; }
		public string Type { get; set; }
		public string URL { get; set; }
	}
}
