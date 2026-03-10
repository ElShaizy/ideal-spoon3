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
	public class Properties : ModelBase
	{
		[JsonIgnore]
		public CSGenioAproperties klass { get { return baseklass as CSGenioAproperties; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Properties.ValCodproperties_pk")]
		public string ValCodproperties_pk { get { return klass.ValCodproperties_pk; } set { klass.ValCodproperties_pk = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Properties.ValBroker_fk")]
		public string ValBroker_fk { get { return klass.ValBroker_fk; } set { klass.ValBroker_fk = value; } }

		private Broker _broker;
		[DisplayName("Broker")]
		[ShouldSerialize("Broker")]
		public virtual Broker Broker
		{
			get
			{
				if (!isEmptyModel && (_broker == null || (!string.IsNullOrEmpty(ValBroker_fk) && (_broker.isEmptyModel || _broker.klass.QPrimaryKey != ValBroker_fk))))
					_broker = Models.Broker.Find(ValBroker_fk, m_userContext, Identifier, _fieldsToSerialize);
				_broker ??= new Models.Broker(m_userContext, true, _fieldsToSerialize);
				return _broker;
			}
			set { _broker = value; }
		}

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Properties.ValCodcity_fk")]
		public string ValCodcity_fk { get { return klass.ValCodcity_fk; } set { klass.ValCodcity_fk = value; } }

		private City _city;
		[DisplayName("City")]
		[ShouldSerialize("City")]
		public virtual City City
		{
			get
			{
				if (!isEmptyModel && (_city == null || (!string.IsNullOrEmpty(ValCodcity_fk) && (_city.isEmptyModel || _city.klass.QPrimaryKey != ValCodcity_fk))))
					_city = Models.City.Find(ValCodcity_fk, m_userContext, Identifier, _fieldsToSerialize);
				_city ??= new Models.City(m_userContext, true, _fieldsToSerialize);
				return _city;
			}
			set { _city = value; }
		}

		[DisplayName("Main Photo")]
		/// <summary>Field : "Main Photo" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Properties.ValMain_photo")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValMain_photo { get { return new ImageModel(klass.ValMain_photo) { Ticket = ValMain_photoQTicket }; } set { klass.ValMain_photo = value; } }
		[JsonIgnore]
		public string ValMain_photoQTicket = null;

		[DisplayName("Title")]
		/// <summary>Field : "Title" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Properties.ValTitle")]
		public string ValTitle { get { return klass.ValTitle; } set { klass.ValTitle = value; } }

		[DisplayName("Price")]
		/// <summary>Field : "Price" Tipo: "$" Formula:  ""</summary>
		[ShouldSerialize("Properties.ValPrice")]
		[CurrencyAttribute("EUR", 4)]
		public decimal? ValPrice { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPrice, 4)); } set { klass.ValPrice = Convert.ToDecimal(value); } }

		[DisplayName("size m2")]
		/// <summary>Field : "size m2" Tipo: "ND" Formula:  ""</summary>
		[ShouldSerialize("Properties.ValSizem2")]
		[NumericAttribute(2)]
		public decimal? ValSizem2 { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValSizem2, 2)); } set { klass.ValSizem2 = Convert.ToDecimal(value); } }

		[DisplayName("Bathroom count")]
		/// <summary>Field : "Bathroom count" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Properties.ValBathroomsnumber")]
		[NumericAttribute(0)]
		public decimal? ValBathroomsnumber { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValBathroomsnumber, 0)); } set { klass.ValBathroomsnumber = Convert.ToDecimal(value); } }

		[DisplayName("Construction date")]
		/// <summary>Field : "Construction date" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Properties.ValDateconstruction")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDateconstruction { get { return klass.ValDateconstruction; } set { klass.ValDateconstruction = value ?? DateTime.MinValue; } }

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Properties.ValDescription")]
		[DataType(DataType.MultilineText)]
		public string ValDescription { get { return klass.ValDescription; } set { klass.ValDescription = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Properties.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Properties(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAproperties(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Properties(UserContext userContext, CSGenioAproperties val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAproperties csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "broker":
						_broker ??= new Broker(m_userContext, true, _fieldsToSerialize);
						_broker.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "city":
						_city ??= new City(m_userContext, true, _fieldsToSerialize);
						_city.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Properties Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAproperties>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Properties(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Properties> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAproperties>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Properties>((r) => new Properties(userCtx, r));
		}

// USE /[MANUAL TRA MODEL PROPERTIES]/
	}
}
