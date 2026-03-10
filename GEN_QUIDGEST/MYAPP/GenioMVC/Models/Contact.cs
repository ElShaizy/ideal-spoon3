using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace GenioMVC.Models
{
	public class Contact : ModelBase
	{
		[JsonIgnore]
		public CSGenioAcontact klass { get { return baseklass as CSGenioAcontact; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "Contact" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Contact.ValCodcontact")]
		public string ValCodcontact { get { return klass.ValCodcontact; } set { klass.ValCodcontact = value; } }

		[DisplayName("Date")]
		/// <summary>Field : "Date" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Contact.ValDate")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDate { get { return klass.ValDate; } set { klass.ValDate = value ?? DateTime.MinValue; } }

		[DisplayName("properties")]
		/// <summary>Field : "properties" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Contact.ValCodproperties_fk")]
		public string ValCodproperties_fk { get { return klass.ValCodproperties_fk; } set { klass.ValCodproperties_fk = value; } }

		private Properties _properties;
		[DisplayName("Properties")]
		[ShouldSerialize("Properties")]
		public virtual Properties Properties
		{
			get
			{
				if (!isEmptyModel && (_properties == null || (!string.IsNullOrEmpty(ValCodproperties_fk) && (_properties.isEmptyModel || _properties.klass.QPrimaryKey != ValCodproperties_fk))))
					_properties = Models.Properties.Find(ValCodproperties_fk, m_userContext, Identifier, _fieldsToSerialize);
				_properties ??= new Models.Properties(m_userContext, true, _fieldsToSerialize);
				return _properties;
			}
			set { _properties = value; }
		}

		[DisplayName("Client name")]
		/// <summary>Field : "Client name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Contact.ValClient_name")]
		public string ValClient_name { get { return klass.ValClient_name; } set { klass.ValClient_name = value; } }

		[DisplayName("email")]
		/// <summary>Field : "email" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Contact.ValEmailcontact")]
		public string ValEmailcontact { get { return klass.ValEmailcontact; } set { klass.ValEmailcontact = value; } }

		[DisplayName("phone number")]
		/// <summary>Field : "phone number" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Contact.ValPhonecontact")]
		[NumericAttribute(0)]
		public decimal? ValPhonecontact { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPhonecontact, 0)); } set { klass.ValPhonecontact = Convert.ToDecimal(value); } }

		[DisplayName("description")]
		/// <summary>Field : "description" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Contact.ValDescription")]
		[DataType(DataType.MultilineText)]
		public string ValDescription { get { return klass.ValDescription; } set { klass.ValDescription = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Contact.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Contact(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAcontact(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Contact(UserContext userContext, CSGenioAcontact val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAcontact csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "properties":
						_properties ??= new Properties(m_userContext, true, _fieldsToSerialize);
						_properties.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					default:
						break;
				}
			}
		}

		/// <summary>
		/// Search the row by key.
		/// </summary>
		/// <param name="id">The primary key.</param>
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Contact Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAcontact>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Contact(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Contact> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAcontact>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Contact>((r) => new Contact(userCtx, r));
		}

// USE /[MANUAL TRA MODEL CONTACT]/
	}
}
