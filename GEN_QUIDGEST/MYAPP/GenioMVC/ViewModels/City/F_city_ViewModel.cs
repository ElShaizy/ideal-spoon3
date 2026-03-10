using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Text.Json.Serialization;

namespace GenioMVC.ViewModels.City
{
	public class F_city_ViewModel : FormViewModel<Models.City>, IPreparableForSerialization
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		#region Foreign keys
		/// <summary>
		/// Title: "Country" | Type: "CE"
		/// </summary>
		public string ValCodcountry_fk { get; set; }

		#endregion
		/// <summary>
		/// Title: "City" | Type: "C"
		/// </summary>
		public string ValCity { get; set; }
		/// <summary>
		/// Title: "Country" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Country> TableCountryCountry { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodcity_pk { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public F_city_ViewModel() : base(null!) { }

		public F_city_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FF_CITY", nestedForm) { }

		public F_city_ViewModel(UserContext userContext, Models.City row, bool nestedForm = false) : base(userContext, "FF_CITY", row, nestedForm) { }

		public F_city_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("city", id);
			Model = Models.City.Find(id, userContext, "FF_CITY", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
			this.RoleToEdit = CSGenio.framework.Role.ROLE_1;
		}

		#region Form conditions

		public override StatusMessage InsertConditions()
		{
			return InsertConditions(m_userContext);
		}

		public static StatusMessage InsertConditions(UserContext userContext)
		{
			var m_userContext = userContext;
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.City model = new Models.City(userContext) { Identifier = "FF_CITY" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FF_CITY");
			if (navigation != null)
				model.LoadKeysFromHistory(navigation, navigation.CurrentLevel.Level);

			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.UPDATE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage DeleteConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.DELETE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage ViewConditions()
		{
			var model = Model;
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.City m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (City) to ViewModel (F_city) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodcountry_fk = ViewModelConversion.ToString(m.ValCodcountry_fk);
				ValCity = ViewModelConversion.ToString(m.ValCity);
				ValCodcity_pk = ViewModelConversion.ToString(m.ValCodcity_pk);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (City) to ViewModel (F_city) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.City m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (F_city) to Model (City) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodcountry_fk = ViewModelConversion.ToString(ValCodcountry_fk);
				m.ValCity = ViewModelConversion.ToString(ValCity);
				m.ValCodcity_pk = ViewModelConversion.ToString(ValCodcity_pk);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (F_city) to Model (City) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
				throw;
			}
		}

		/// <summary>
		/// Sets the value of a single property of the view model based on the provided table and field names.
		/// </summary>
		/// <param name="fullFieldName">The full field name in the format "table.field".</param>
		/// <param name="value">The field value.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="fullFieldName"/> is null.</exception>
		public override void SetViewModelValue(string fullFieldName, object value)
		{
			try
			{
				ArgumentNullException.ThrowIfNull(fullFieldName);
				// Obtain a valid value from JsonValueKind that can come from "prefillValues" during the pre-filling of fields during insertion
				var _value = ViewModelConversion.ToRawValue(value);

				switch (fullFieldName)
				{
					case "city.codcountry_fk":
						this.ValCodcountry_fk = ViewModelConversion.ToString(_value);
						break;
					case "city.city":
						this.ValCity = ViewModelConversion.ToString(_value);
						break;
					case "city.codcity_pk":
						this.ValCodcity_pk = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (F_city) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (F_city)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.City.Find(id ?? Navigation.GetStrValue("city"), m_userContext, "FF_CITY"); }
			finally { Model ??= new Models.City(m_userContext) { Identifier = "FF_CITY" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.City.Find(Navigation.GetStrValue("city"), m_userContext, "FF_CITY");
			}
			finally
			{
				if (Model == null)
					throw new ModelNotFoundException("Model not found");

				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
					LoadDefaultValues();
				else
					oldvalues = Model.klass;
			}

			Model.Identifier = "FF_CITY";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				// TODO: It needs to be analyzed whether we should disable the security of field filling here. If there is any case where the field with the block condition can only be calculated after the double calculation of the formulas.
				MapToModel(Model);

				// If it's inserting or duplicating, needs to fill the default values.
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					FunctionType funcType = Navigation.CurrentLevel.FormMode == FormMode.New
						? FunctionType.INS
						: FunctionType.DUP;

					Model.baseklass.fillValuesDefault(m_userContext.PersistentSupport, funcType);
				}

				// Preencher operações internas
				Model.klass.fillInternalOperations(m_userContext.PersistentSupport, oldvalues);
				MapFromModel(Model);
			}

			// Load just the selected row primary keys for checklists.
			// Needed for submitting forms incase checklists are in collapsible zones that have not been expanded to load the checklist data.
			LoadChecklistsSelectedIDs();
		}

		protected override void FillExtraProperties()
		{
		}
		
		protected override void LoadDocumentsProperties(Models.City row)
		{
		}

		/// <summary>
		/// Load Partial
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public override void LoadPartial(NameValueCollection qs, bool lazyLoad = false)
		{
			// MH [bugfix] - Quando o POST da ficha falha, ao recaregar a view os documentos na BD perdem alguma informação (ex: name do file)
			if (Model == null)
			{
				// Precisamos fazer o Find to obter as chaves dos documentos que já foram anexados
				// TODO: Conseguir passar estas chaves no POST to poder retirar o Find.
				Model = Models.City.Find(Navigation.GetStrValue("city"), m_userContext, "FF_CITY");
				if (Model == null)
				{
					Model = new Models.City(m_userContext) { Identifier = "FF_CITY" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("city");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_F_city__country__country(qs, lazyLoad);

// USE /[MANUAL TRA VIEWMODEL_LOADPARTIAL F_CITY]/
		}

// USE /[MANUAL TRA VIEWMODEL_NEW F_CITY]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValCity", Resources.Resources.CITY42505, ValCity, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL TRA VIEWMODEL_SAVE F_CITY]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL TRA VIEWMODEL_APPLY F_CITY]/

// USE /[MANUAL TRA VIEWMODEL_DUPLICATE F_CITY]/

// USE /[MANUAL TRA VIEWMODEL_DESTROY F_CITY]/
		public override void Destroy(string id)
		{
			Model = Models.City.Find(id, m_userContext, "FF_CITY");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		/// <summary>
		/// Load selected row primary keys for all checklists
		/// </summary>
		public void LoadChecklistsSelectedIDs()
		{
		}

		/// <summary>
		/// TableCountryCountry -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_F_city__country__country(NameValueCollection qs, bool lazyLoad = false)
		{
			bool f_city__country__countryDoLoad = true;
			CriteriaSet f_city__country__countryConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("country", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					f_city__country__countryConds.Equal(CSGenioAcountry.FldCodcountry_pk, hValue);
					this.ValCodcountry_fk = DBConversion.ToString(hValue);
				}
			}

			TableCountryCountry = new TableDBEdit<Models.Country>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_country") != null)
				{
					this.ValCodcountry_fk = Navigation.GetStrValue("RETURN_country");
					Navigation.CurrentLevel.SetEntry("RETURN_country", null);
				}
				FillDependant_F_cityTableCountryCountry(lazyLoad);
				return;
			}

			if (f_city__country__countryDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableCountryCountry, "sTableCountryCountry", "dTableCountryCountry", qs, "country");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableCountryCountry_tableFilters"]))
					TableCountryCountry.TableFilters = bool.Parse(qs["TableCountryCountry_tableFilters"]);
				else
					TableCountryCountry.TableFilters = false;

				query = qs["qTableCountryCountry"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAcountry.FldCountry, query + "%");
				}
				f_city__country__countryConds.SubSet(search_filters);

				string tryParsePage = qs["pTableCountryCountry"] != null ? qs["pTableCountryCountry"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAcountry.FldCodcountry_pk, CSGenioAcountry.FldCountry, CSGenioAcountry.FldZzstate];

// USE /[MANUAL TRA OVERRQ F_CITY_COUNTRYCOUNTRY]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("country", FormMode.New) || Navigation.checkFormMode("country", FormMode.Duplicate))
					f_city__country__countryConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcountry.FldZzstate, 0)
						.Equal(CSGenioAcountry.FldCodcountry_pk, Navigation.GetStrValue("country")));
				else
					f_city__country__countryConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcountry.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("country", "country");
				ListingMVC<CSGenioAcountry> listing = Models.ModelBase.Where<CSGenioAcountry>(m_userContext, false, f_city__country__countryConds, fields, offset, numberItems, sorts, "LED_F_CITY__COUNTRY__COUNTRY", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCountryCountry.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCountryCountry.Query = query;
				TableCountryCountry.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Country(m_userContext, r, true, _fieldsToSerialize_F_CITY__COUNTRY__COUNTRY));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_country") != null)
				{
					this.ValCodcountry_fk = Navigation.GetStrValue("RETURN_country");
					Navigation.CurrentLevel.SetEntry("RETURN_country", null);
				}

				TableCountryCountry.List = new SelectList(TableCountryCountry.Elements.ToSelectList(x => x.ValCountry, x => x.ValCodcountry_pk,  x => x.ValCodcountry_pk == this.ValCodcountry_fk), "Value", "Text", this.ValCodcountry_fk);
				FillDependant_F_cityTableCountryCountry();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCountryCountry (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Country</param>
		public ConcurrentDictionary<string, object> GetDependant_F_cityTableCountryCountry(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAcountry.FldCodcountry_pk, CSGenioAcountry.FldCountry];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAcountry tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAcountry.FldCodcountry_pk, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableCountryCountry (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_F_cityTableCountryCountry(bool lazyLoad = false)
		{
			var row = GetDependant_F_cityTableCountryCountry(this.ValCodcountry_fk);
			try
			{

				// Fill List fields
				this.ValCodcountry_fk = ViewModelConversion.ToString(row["country.codcountry_pk"]);
				TableCountryCountry.Value = (string)row["country.country"];
				if (GenFunctions.emptyG(this.ValCodcountry_fk) == 1)
				{
					this.ValCodcountry_fk = "";
					TableCountryCountry.Value = "";
					Navigation.ClearValue("country");
				}
				else if (lazyLoad)
				{
					TableCountryCountry.SetPagination(1, 0, false, false, 1);
					TableCountryCountry.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodcountry_fk),
							Text = Convert.ToString(TableCountryCountry.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodcountry_fk);
				}

				TableCountryCountry.Selected = this.ValCodcountry_fk;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCountryCountry): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_F_CITY__COUNTRY__COUNTRY = ["Country", "Country.ValCodcountry_pk", "Country.ValZzstate", "Country.ValCountry"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"city.codcountry_fk" => ViewModelConversion.ToString(modelValue),
				"city.city" => ViewModelConversion.ToString(modelValue),
				"city.codcity_pk" => ViewModelConversion.ToString(modelValue),
				"country.codcountry_pk" => ViewModelConversion.ToString(modelValue),
				"country.country" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL TRA VIEWMODEL_CUSTOM F_CITY]/

		#endregion
	}
}
