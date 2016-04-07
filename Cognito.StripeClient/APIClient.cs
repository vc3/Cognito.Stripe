using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Cognito.Stripe;
using System.Reflection;
using Cognito.Stripe.Classes;
using Cognito.StripeClient.Arguments;
using Cognito.Stripe.Helpers;
using Cognito.StripeClient.Converters;
using System.Collections;

namespace Cognito.StripeClient
{
	public class APIClient
	{
		public static string BaseAPIUrl = "https://api.stripe.com";

		protected APIClient()
		{
		}

		public APIClient(string apiKey, string baseUrl = null, APIVersion version = APIVersion.v1)
			: this()
		{
			ApiKey = apiKey;
			APIVersion = version;
			BaseUrl = !String.IsNullOrWhiteSpace(baseUrl) ? baseUrl : BaseAPIUrl;
		}

		protected string BaseUrl { get; set; }
		protected APIVersion APIVersion { get; set; }
		protected string ApiKey { get; set; }

		public T Create<T>(CreateArguments args, bool throwExceptions = false)
			where T : BaseObject
		{
			return ProcessRequest<T>(args, RequestMethod.Post, throwExceptions: throwExceptions);
		}

		public T Get<T>(GetArguments args, bool throwExceptions = false)
			where T : BaseObject
		{
			return ProcessRequest<T>(args, RequestMethod.Get, throwExceptions: throwExceptions);
		}

		public StripeList<T> List<T>(ListArguments args, bool throwExceptions = false)
			where T : BaseObject
		{
			return ProcessListRequest<T>(args, RequestMethod.Get, throwExceptions: throwExceptions);
		}

		public T Delete<T>(DeleteArguments args, bool throwExceptions = false)
			where T : BaseObject
		{
			return ProcessRequest<T>(args, RequestMethod.Delete, throwExceptions: throwExceptions);
		}

		public T Update<T>(UpdateArguments args, bool throwExceptions = false)
			where T : BaseObject
		{
			return ProcessRequest<T>(args, RequestMethod.Post, throwExceptions: throwExceptions);
		}

		public string Create(CreateArguments args, bool throwExceptions = false)
		{
			return ProcessRawRequest(args, RequestMethod.Post, throwExceptions: throwExceptions);
		}

		public string Get(GetArguments args, bool throwExceptions = false)
		{
			return ProcessRawRequest(args, RequestMethod.Get, throwExceptions: throwExceptions);
		}

		public string List(ListArguments args, bool throwExceptions = false)
		{
			return ProcessRawRequest(args, RequestMethod.Get, throwExceptions: throwExceptions);
		}

		public string Delete(DeleteArguments args, bool throwExceptions = false)
		{
			return ProcessRawRequest(args, RequestMethod.Delete, throwExceptions: throwExceptions);
		}

		public string Update(UpdateArguments args, bool throwExceptions = false)
		{
			return ProcessRawRequest(args, RequestMethod.Post, throwExceptions: throwExceptions);
		}

		StripeList<T> ProcessListRequest<T>(BaseArguments args, RequestMethod method, bool throwExceptions)
			where T : BaseObject
		{
			var result = SendRequest(CreateRequest(args.GetEndpoint(), args.IdempotencyKey).WithParameters(args).WithQueryStringArgs(args.Parse(this)), method);
			var List = new StripeList<T> { Data = new List<T>() };

			// ensure the  error object is populated
			if (!result.IsSuccessStatusCode)
			{
				var Obj = JsonUtility.Deserialize<T>(result.Content);

				Obj.Error = Obj.Error ?? new Error();
				Obj.Error.ResponseCode = Obj.Error.ResponseCode.HasValue ? Obj.Error.ResponseCode.Value : (int)result.StatusCode;
				Obj.Error.Message = !String.IsNullOrWhiteSpace(Obj.Error.Message) ? Obj.Error.Message : result.StatusMessage;

				if (throwExceptions)
					throw new ApplicationException(Obj.Error.Message);

				List.Data.Add(Obj);
			}
			else
				List = JsonUtility.Deserialize<StripeList<T>>(result.Content);

			return List;
		}

		T ProcessRequest<T>(BaseArguments args, RequestMethod method, bool throwExceptions = false)
			where T : BaseObject
		{
			var result = SendRequest(CreateRequest(args.GetEndpoint(), args.IdempotencyKey).WithParameters(args).WithQueryStringArgs(args.Parse(this)), method);

			T Obj = JsonUtility.Deserialize<T>(result.Content);

			// ensure the  error object is populated
			if (!result.IsSuccessStatusCode)
			{
				Obj.Error = Obj.Error ?? new Error();
				Obj.Error.ResponseCode = Obj.Error.ResponseCode.HasValue ? Obj.Error.ResponseCode.Value : (int)result.StatusCode;
				Obj.Error.Message = !String.IsNullOrWhiteSpace(Obj.Error.Message) ? Obj.Error.Message : result.StatusMessage;

				if (throwExceptions)
					throw new ApplicationException(Obj.Error.Message);
			}
			
			return Obj;
		}

		string ProcessRawRequest(BaseArguments args, RequestMethod method, bool throwExceptions = false)
		{
			var result = SendRequest(CreateRequest(args.GetEndpoint(), args.IdempotencyKey).WithQueryStringArgs(args.Parse(this)), method);

			if (!result.IsSuccessStatusCode && throwExceptions)
				throw new ApplicationException(result.StatusMessage);
			
			return result.Content;
		}

		Request CreateRequest(string endpoint, string idempotencyKey)
		{
			var request = new Request(BaseUrl, (APIVersion.ToString() + "/" + endpoint))
				.WithHeader("Authorization", "Bearer " + ApiKey);

			if (!String.IsNullOrWhiteSpace(idempotencyKey))
				request.WithHeader("Idempotency-Key", idempotencyKey);

			return request;
		}

		Response SendRequest(Request request, RequestMethod method)
		{
			Response result = null;
			switch (method)
			{
				case RequestMethod.Get:
					result = request.SendAsGet();
					break;
				case RequestMethod.Post:
					result = request.SendAsPost();
					break;
				case RequestMethod.Put:
					result = request.SendAsPut();
					break;
				case RequestMethod.Delete:
					result = request.SendAsDelete();
					break;
			}

			return result;
		}

		public static T DeserializeObject<T>(string json)
			where T : BaseObject
		{
			return JsonUtility.Deserialize<T>(json);
		}

		public static string SerializeObject(BaseObject obj)
		{
			return JsonUtility.Serialize(obj);
		}
	}

	public enum APIVersion
	{ 
		v1 = 1
	}

	public enum RequestMethod
	{ 
		Get,
		Post,
		Put,
		Delete
	}
}