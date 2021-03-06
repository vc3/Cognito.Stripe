﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.StripeClient
{
	internal sealed class Response
	{
		public string Content { get; set; }

		public HttpStatusCode StatusCode { get; set; }

		public string StatusMessage { get; set; }

		public bool IsSuccessStatusCode { get { return StatusCode == HttpStatusCode.OK; } }
	}
}
