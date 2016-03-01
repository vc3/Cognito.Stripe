using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.StripeClient.Arguments
{
	public class EventGetArguments : GetArguments
	{
		[JsonIgnore]
		public override string ObjectName { get { return "events"; } }
	}

	public class EventSearchArguments : SearchArguments
	{
		[JsonIgnore]
		public override string ObjectName { get { return "events"; } }
	}
}
