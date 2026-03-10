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
	public class Country : ModelBase
	{
		[JsonIgnore]
		public CSGenioAcountry klass { get { return baseklass as CSGenioAcountry; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "country" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Country.ValCodcountry_pk")]
		public string ValCodcountry_pk { get { return klass.ValCodcountry_pk; } set { klass.ValCodcountry_pk = value; } }

		[DisplayName("Country")]
		/// <summary>Field : "Country" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Country.ValCountry")]
		public string ValCountry { get { return klass.ValCountry; } set { klass.ValCountry = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Country.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Country(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAcountry(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Country(UserContext userContext, CSGenioAcountry val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAcountry csgenioa)
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
		public static Country Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAcountry>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Country(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Country> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAcountry>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Country>((r) => new Country(userCtx, r));
		}

// USE /[MANUAL TRA MODEL COUNTRY]/
	}
}
