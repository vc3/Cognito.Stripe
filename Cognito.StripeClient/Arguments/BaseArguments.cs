using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognito.Stripe;
using System.Collections.Specialized;
using System.Reflection;
using Cognito.StripeClient.Converters;
using System.Web;
using Cognito.Stripe.Helpers;
using System.Collections;

namespace Cognito.StripeClient.Arguments
{
	public class BaseArguments
	{
		[JsonIgnore]
		public virtual string ObjectName { get { return ""; } }

		[JsonIgnore]
		public string IdempotencyKey { get; set; }

		#region Methods
		public virtual NameValueCollection Parse(APIClient client, NameValueCollection collection = null, string prefix = null)
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

				var valueSet = argValue != null && (!String.IsNullOrWhiteSpace(argValue.ToString()) || this is UpdateArguments);

				if (valueSet)
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
							if (val != null)
								val.Parse(client, argCollection, key);
						}
						else
						{
							var convertToCents = property.GetCustomAttribute<CurrencyAttribute>();

							// parse ICollection properties
							if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
							{
								var valuesArray = new List<string>();
								var propValues = argValue as ICollection;

								foreach (var propVal in propValues)
								{
									var paramVal = convertToCents != null ? ConvertToCents(propVal, currencyProp) : propVal;
									if (paramVal != null)
										valuesArray.Add(paramVal.ToString());
								}

								key = String.Format("{0}[]", key.ToLower());
								argCollection.Add(key, String.Join(String.Format("&{0}=", key), valuesArray));
							}
							else
							{
								if (argValue is decimal? && ((decimal?)argValue).HasValue)
								{
									if (convertToCents != null)
										argValue = ConvertToCents(argValue, currencyProp);
								}
								else if (argValue is DateTime? && ((DateTime?)argValue).HasValue)
									argValue = DateTimeConverter.ConvertToSeconds(argValue as DateTime?);

								var objectType = property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(property.PropertyType) : property.PropertyType;
								var paramValue = typeof(Lookup).IsAssignableFrom(objectType) ? ((Lookup)argValue).Code : argValue.ToString();
								if (objectType.IsEnum)
									paramValue = paramValue.ToLower();

								argCollection.Add(key.ToLower(), HttpUtility.UrlEncode(paramValue));
							}
						}
					}
				}
			}

			return argCollection;
		}

		public virtual string GetEndpoint() { return ""; }

		protected int? ConvertToCents(object argValue, PropertyInfo currencyProp)
		{
			if (currencyProp == null)
				return null;
		
			Currency currency = currencyProp.GetValue(this) as Currency ?? Currency.USD;
			return BaseObject.GetAmountNoDecimal((decimal?)argValue, currency);
		}
		#endregion
	}

	public class BaseReadArguments : BaseArguments
	{
		public BaseReadArguments() { ExpandedProperties = new List<string>(); }

		[JsonIgnore]
		public ICollection<string> ExpandedProperties { get; private set; }

		public override NameValueCollection Parse(APIClient client, NameValueCollection collection = null, string prefix = null)
		{
			var argCollection = base.Parse(client, collection, prefix);
			
			if (ExpandedProperties.Count > 0)
				argCollection.Add("expand[]", String.Join("&expand[]=", ExpandedProperties));

			return argCollection;
		}

		protected void ToggleExpandedProperty(bool expand, string propertyPath)
		{
			if (expand)
				ExpandProperty(propertyPath);
			else
				CollapseProperty(propertyPath);
		}

		void ExpandProperty(string propertyPath)
		{
			if (!ExpandedProperties.Contains(propertyPath))
				ExpandedProperties.Add(propertyPath);
		}

		void CollapseProperty(string propertyPath)
		{
			if (ExpandedProperties.Contains(propertyPath))
				ExpandedProperties.Remove(propertyPath);
		}
	}

	public class BaseModifyArguments : BaseArguments
	{
		public BaseModifyArguments() { Metadata = new Dictionary<string, string>(); }

		public Dictionary<string, string> Metadata { get; set; }
	}

	public class GetArguments : BaseReadArguments
	{
		[JsonIgnore]
		public string Id { get; set; }

		public override string GetEndpoint()
		{
			return ObjectName + "/" + Id;
		}
	}

	public class ListArguments : BaseReadArguments
	{
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
	}

	public class CreateArguments : BaseModifyArguments
	{
		public override string GetEndpoint()
		{
			return ObjectName;
		}
	}

	public class UpdateArguments : BaseModifyArguments
	{
		[JsonIgnore]
		public string Id { get; set; }

		public override string GetEndpoint()
		{
			return ObjectName + "/" + Id;
		}
	}

	public class DeleteArguments : BaseArguments
	{
		[JsonIgnore]
		public string Id { get; set; }

		public override string GetEndpoint()
		{
			return ObjectName +  "/" + Id;
		}
	}
}
