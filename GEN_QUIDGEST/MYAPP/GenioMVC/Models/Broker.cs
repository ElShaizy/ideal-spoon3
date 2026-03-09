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
	public class Broker : ModelBase
	{
		[JsonIgnore]
		public CSGenioAbroker klass { get { return baseklass as CSGenioAbroker; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Broker.ValCodbroker")]
		public string ValCodbroker { get { return klass.ValCodbroker; } set { klass.ValCodbroker = value; } }

		[DisplayName("Photo")]
		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Broker.ValMain photo")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValMain photo { get { return new ImageModel(klass.ValMain photo) { Ticket = ValMain photoQTicket }; } set { klass.ValMain photo = value; } }
		[JsonIgnore]
		public string ValMain photoQTicket = null;

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Broker.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Birthdate")]
		/// <summary>Field : "Birthdate" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Broker.ValBirthdate")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValBirthdate { get { return klass.ValBirthdate; } set { klass.ValBirthdate = value ?? DateTime.MinValue; } }

		[DisplayName("Email")]
		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Broker.ValEmail")]
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }

		[DisplayName("Phone Number")]
		/// <summary>Field : "Phone Number" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Broker.ValPhone number")]
		[NumericAttribute(0)]
		public decimal? ValPhone number { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPhone number, 0)); } set { klass.ValPhone number = Convert.ToDecimal(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Broker.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Broker(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAbroker(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Broker(UserContext userContext, CSGenioAbroker val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAbroker csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
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
		public static Broker Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAbroker>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Broker(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Broker> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAbroker>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Broker>((r) => new Broker(userCtx, r));
		}

// USE /[MANUAL TRA MODEL BROKER]/
	}
}
