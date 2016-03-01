﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognito.Stripe;
using System.Collections.Specialized;
using System.Reflection;
using Cognito.Stripe.Converters;
using System.Web;
using Cognito.Stripe.Helpers;

namespace Cognito.StripeClient.Arguments
{
	public abstract class BaseArguments
	{
		public BaseArguments() { Metadata = new Dictionary<string, string>(); ExpandedProperties = new List<string>(); }

		public Dictionary<string, string> Metadata { get; set; }

		public virtual string GetEndpoint() { return ""; }

		public virtual string ObjectName { get { return ""; } }

		[JsonIgnore]
		public ICollection<string> ExpandedProperties { get; private set; }

		protected NameValueCollection ParseBaseArguments(BaseClient client, NameValueCollection collection = null, string prefix = null)
		{
			NameValueCollection argCollection = collection ?? new NameValueCollection();

			var currencyProp = GetType().GetProperty("Currency");

			foreach (var property in GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
			{
				var jsonProperty = property.GetCustomAttribute<JsonPropertyAttribute>();
				var jsonIgnore = property.GetCustomAttribute<JsonIgnoreAttribute>();

				if (jsonIgnore != null)
					continue;

				var argName = jsonProperty == null ? property.Name : jsonProperty.PropertyName;
				var argValue = property.GetValue(this);

				if (argValue != null && !String.IsNullOrWhiteSpace(argValue.ToString()))
				{
					if (property.PropertyType == typeof(Dictionary<string, string>))
					{
						var dictionary = (Dictionary<string, string>)argValue;

						if (dictionary != null && (!argName.Equals("metadata", StringComparison.OrdinalIgnoreCase) || String.IsNullOrWhiteSpace(prefix)))
						{
							foreach (var key in dictionary.Keys)
								argCollection.Add(String.Format("{0}[{1}]", argName.ToLower(), key), HttpUtility.UrlEncode(dictionary[key]));
						}
					}
					else
					{
						var key = !String.IsNullOrWhiteSpace(prefix) ? (String.Format("{0}[{1}]", prefix, argName)) : argName;

						if (argValue is BaseArguments)
						{
							var val = argValue as BaseArguments;
							if(val != null)
								val.ParseBaseArguments(client, argCollection, key);
						}
						else
						{
							if (argValue is decimal? && ((decimal?)argValue).HasValue)
							{
								var convertToCents = property.GetCustomAttribute<CentsAttribute>();
								if (convertToCents != null)
								{
									if (currencyProp != null)
									{
										Currency currency = currencyProp.GetValue(this) as Currency ?? Currency.USD;
										argValue = BaseObject.GetAmountNoDecimal((decimal?)argValue, currency);
									}
								}
							}
							else if (argValue is DateTime? && ((DateTime?)argValue).HasValue)
								argValue = DateTimeConverter.ConvertToSeconds(argValue as DateTime?);

							var paramValue = typeof(Lookup).IsAssignableFrom(property.PropertyType) ? ((Lookup)argValue).Code : argValue.ToString();

							argCollection.Add(key.ToLower(), HttpUtility.UrlEncode(paramValue));
						}
					}
				}
			}

			if(ExpandedProperties.Count > 0)
				argCollection.Add("expand[]", String.Join("&expand[]=", ExpandedProperties));

			return argCollection;
		}

		public virtual NameValueCollection ParseArguments(BaseClient client, NameValueCollection collection = null, string prefix = null)
		{
			return ParseBaseArguments(client, collection, prefix);
		}
	}

	public abstract class SearchArguments : BaseArguments
	{
		public string Id { get; set; }
		public DateTime? Created { get; set; }

		[JsonProperty("created[gt]")]
		public DateTime? CreatedAfter { get; set; }
		[JsonProperty("created[gte]")]
		public DateTime? CreatedOnOrAfter { get; set; }
		[JsonProperty("created[lt]")]
		public DateTime? CreatedBefore { get; set; }
		[JsonProperty("created[lte]")]
		public DateTime? CreatedOnOrBefore { get; set; }
		[JsonProperty("starting_after")]
		public string StartingAfter { get; set; }
		[JsonProperty("ending_before")]
		public string EndingBefore { get; set; }
		public int? Limit { get; set; }

		public override string GetEndpoint()
		{
			return ObjectName;
		}

		public override NameValueCollection ParseArguments(BaseClient client, NameValueCollection collection = null, string prefix = null)
		{
			return base.ParseArguments(client, collection, prefix);
		}
	}

	public abstract class CreateArguments : BaseArguments
	{
		public override string GetEndpoint()
		{
			return ObjectName;
		}

		public override NameValueCollection ParseArguments(BaseClient client, NameValueCollection collection = null, string prefix = null)
		{
			return base.ParseArguments(client, collection, prefix);
		}
	}

	public abstract class GetArguments : BaseArguments
	{
		[JsonIgnore]
		public string Id { get; set; }

		public override string GetEndpoint()
		{
			return ObjectName + "/" + Id;
		}

		public override NameValueCollection ParseArguments(BaseClient client, NameValueCollection collection = null, string prefix = null)
		{
			return new NameValueCollection();
		}
	}

	public abstract class UpdateArguments : BaseArguments
	{
		[JsonIgnore]
		public string Id { get; set; }

		public override string GetEndpoint()
		{
			return ObjectName + "/" + Id;
		}

		public override NameValueCollection ParseArguments(BaseClient client, NameValueCollection collection = null, string prefix = null)
		{
			return base.ParseArguments(client, collection, prefix);
		}
	}

	public abstract class DeleteArguments : BaseArguments
	{
		[JsonIgnore]
		public string Id { get; set; }

		public override string GetEndpoint()
		{
			return ObjectName +  "/" + Id;
		}

		public override NameValueCollection ParseArguments(BaseClient client, NameValueCollection collection = null, string prefix = null)
		{
			return base.ParseArguments(client, collection, prefix);
		}
	}
}