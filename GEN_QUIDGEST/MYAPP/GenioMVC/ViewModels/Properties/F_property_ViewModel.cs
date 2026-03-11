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

namespace GenioMVC.ViewModels.Properties
{
	public class F_property_ViewModel : FormViewModel<Models.Properties>, IPreparableForSerialization
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
		/// Title: "brokers name" | Type: "CE"
		/// </summary>
		public string ValBroker_fk { get; set; }
		/// <summary>
		/// Title: "City" | Type: "CE"
		/// </summary>
		public string ValCodcity_fk { get; set; }

		#endregion
		/// <summary>
		/// Title: "Main Photo" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(30, 50)]
		public GenioMVC.Models.ImageModel ValMain_photo { get; set; }
		/// <summary>
		/// Title: "sold" | Type: "L"
		/// </summary>
		public bool ValSold { get; set; }
		/// <summary>
		/// Title: "Title" | Type: "C"
		/// </summary>
		public string ValTitle { get; set; }
		/// <summary>
		/// Title: "Price" | Type: "$"
		/// </summary>
		public decimal? ValPrice { get; set; }
		/// <summary>
		/// Title: "Description" | Type: "MO"
		/// </summary>
		public string ValDescription { get; set; }
		/// <summary>
		/// Title: "City" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.City> TableCityCity { get; set; }
		/// <summary>
		/// Title: "Country" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string CityCountryValCountry
		{
			get
			{
				return funcCityCountryValCountry != null ? funcCityCountryValCountry() : _auxCityCountryValCountry;
			}
			set { funcCityCountryValCountry = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcCityCountryValCountry { get; set; }

		private string _auxCityCountryValCountry { get; set; }
		/// <summary>
		/// Title: "Bathroom count" | Type: "N"
		/// </summary>
		public decimal? ValBathroomsnumber { get; set; }
		/// <summary>
		/// Title: "Size" | Type: "C"
		/// </summary>
		public string ValSizem2 { get; set; }
		/// <summary>
		/// Title: "building type" | Type: "AC"
		/// </summary>
		public string ValBuildingtype { get; set; }
		/// <summary>
		/// Title: "Construction date" | Type: "D"
		/// </summary>
		public DateTime? ValDateconstruction { get; set; }
		/// <summary>
		/// Title: "ID" | Type: "N"
		/// </summary>
		public decimal? ValOrder { get; set; }
		/// <summary>
		/// Title: "Typology" | Type: "AN"
		/// </summary>
		public decimal ValTypology { get; set; }
		/// <summary>
		/// Title: "brokers name" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Broker> TableBrokerName { get; set; }
		/// <summary>
		/// Title: "Photo" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(30, 50)]
		[ValidateSetAccess]
		public GenioMVC.Models.ImageModel BrokerValMain_photo
		{
			get
			{
				return funcBrokerValMain_photo != null ? funcBrokerValMain_photo() : _auxBrokerValMain_photo;
			}
			set { funcBrokerValMain_photo = () => value; }
		}

		[JsonIgnore]
		public Func<GenioMVC.Models.ImageModel> funcBrokerValMain_photo { get; set; }

		private GenioMVC.Models.ImageModel _auxBrokerValMain_photo { get; set; }
		/// <summary>
		/// Title: "Email" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string BrokerValEmail
		{
			get
			{
				return funcBrokerValEmail != null ? funcBrokerValEmail() : _auxBrokerValEmail;
			}
			set { funcBrokerValEmail = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcBrokerValEmail { get; set; }

		private string _auxBrokerValEmail { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodproperties { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public F_property_ViewModel() : base(null!) { }

		public F_property_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FF_PROPERTY", nestedForm) { }

		public F_property_ViewModel(UserContext userContext, Models.Properties row, bool nestedForm = false) : base(userContext, "FF_PROPERTY", row, nestedForm) { }

		public F_property_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("properties", id);
			Model = Models.Properties.Find(id, userContext, "FF_PROPERTY", fieldsToQuery: fieldsToLoad);
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
			Models.Properties model = new Models.Properties(userContext) { Identifier = "FF_PROPERTY" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FF_PROPERTY");
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
		public override void MapFromModel(Models.Properties m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Properties) to ViewModel (F_property) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValBroker_fk = ViewModelConversion.ToString(m.ValBroker_fk);
				ValCodcity_fk = ViewModelConversion.ToString(m.ValCodcity_fk);
				ValMain_photo = ViewModelConversion.ToImage(m.ValMain_photo);
				ValSold = ViewModelConversion.ToLogic(m.ValSold);
				ValTitle = ViewModelConversion.ToString(m.ValTitle);
				ValPrice = ViewModelConversion.ToNumeric(m.ValPrice);
				ValDescription = ViewModelConversion.ToString(m.ValDescription);
				ValBathroomsnumber = ViewModelConversion.ToNumeric(m.ValBathroomsnumber);
				ValSizem2 = ViewModelConversion.ToString(m.ValSizem2);
				ValBuildingtype = ViewModelConversion.ToString(m.ValBuildingtype);
				ValDateconstruction = ViewModelConversion.ToDateTime(m.ValDateconstruction);
				ValOrder = ViewModelConversion.ToNumeric(m.ValOrder);
				ValTypology = ViewModelConversion.ToNumeric(m.ValTypology);
				funcBrokerValMain_photo = () => ViewModelConversion.ToImage(m.Broker.ValMain_photo);
				funcBrokerValEmail = () => ViewModelConversion.ToString(m.Broker.ValEmail);
				ValCodproperties = ViewModelConversion.ToString(m.ValCodproperties);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Properties) to ViewModel (F_property) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Properties m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (F_property) to Model (Properties) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValBroker_fk = ViewModelConversion.ToString(ValBroker_fk);
				m.ValCodcity_fk = ViewModelConversion.ToString(ValCodcity_fk);
				if (ValMain_photo == null || !ValMain_photo.IsThumbnail)
					m.ValMain_photo = ViewModelConversion.ToImage(ValMain_photo);
				m.ValSold = ViewModelConversion.ToLogic(ValSold);
				m.ValTitle = ViewModelConversion.ToString(ValTitle);
				m.ValPrice = ViewModelConversion.ToNumeric(ValPrice);
				m.ValDescription = ViewModelConversion.ToString(ValDescription);
				m.ValBathroomsnumber = ViewModelConversion.ToNumeric(ValBathroomsnumber);
				m.ValSizem2 = ViewModelConversion.ToString(ValSizem2);
				m.ValBuildingtype = ViewModelConversion.ToString(ValBuildingtype);
				m.ValDateconstruction = ViewModelConversion.ToDateTime(ValDateconstruction);
				m.ValOrder = ViewModelConversion.ToNumeric(ValOrder);
				m.ValTypology = ViewModelConversion.ToNumeric(ValTypology);
				m.ValCodproperties = ViewModelConversion.ToString(ValCodproperties);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (F_property) to Model (Properties) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "properties.broker_fk":
						this.ValBroker_fk = ViewModelConversion.ToString(_value);
						break;
					case "properties.codcity_fk":
						this.ValCodcity_fk = ViewModelConversion.ToString(_value);
						break;
					case "properties.main_photo":
						this.ValMain_photo = ViewModelConversion.ToImage(_value);
						break;
					case "properties.sold":
						this.ValSold = ViewModelConversion.ToLogic(_value);
						break;
					case "properties.title":
						this.ValTitle = ViewModelConversion.ToString(_value);
						break;
					case "properties.price":
						this.ValPrice = ViewModelConversion.ToNumeric(_value);
						break;
					case "properties.description":
						this.ValDescription = ViewModelConversion.ToString(_value);
						break;
					case "properties.bathroomsnumber":
						this.ValBathroomsnumber = ViewModelConversion.ToNumeric(_value);
						break;
					case "properties.sizem2":
						this.ValSizem2 = ViewModelConversion.ToString(_value);
						break;
					case "properties.buildingtype":
						this.ValBuildingtype = ViewModelConversion.ToString(_value);
						break;
					case "properties.dateconstruction":
						this.ValDateconstruction = ViewModelConversion.ToDateTime(_value);
						break;
					case "properties.order":
						this.ValOrder = ViewModelConversion.ToNumeric(_value);
						break;
					case "properties.typology":
						this.ValTypology = ViewModelConversion.ToNumeric(_value);
						break;
					case "properties.codproperties":
						this.ValCodproperties = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (F_property) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (F_property)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Properties.Find(id ?? Navigation.GetStrValue("properties"), m_userContext, "FF_PROPERTY"); }
			finally { Model ??= new Models.Properties(m_userContext) { Identifier = "FF_PROPERTY" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Properties.Find(Navigation.GetStrValue("properties"), m_userContext, "FF_PROPERTY");
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

			Model.Identifier = "FF_PROPERTY";
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
		
		protected override void LoadDocumentsProperties(Models.Properties row)
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
				Model = Models.Properties.Find(Navigation.GetStrValue("properties"), m_userContext, "FF_PROPERTY");
				if (Model == null)
				{
					Model = new Models.Properties(m_userContext) { Identifier = "FF_PROPERTY" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("properties");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_F_property__city__city(qs, lazyLoad);
			Load_F_property__broker__name(qs, lazyLoad);

// USE /[MANUAL TRA VIEWMODEL_LOADPARTIAL F_PROPERTY]/
		}

// USE /[MANUAL TRA VIEWMODEL_NEW F_PROPERTY]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.Required("ValMain_photo", Resources.Resources.MAIN_PHOTO18723, ViewModelConversion.ToImage(ValMain_photo), FieldType.IMAGE.GetFormatting());
			validator.StringLength("ValTitle", Resources.Resources.TITLE21885, ValTitle, 50);
			validator.StringLength("CityCountryValCountry", Resources.Resources.COUNTRY64133, CityCountryValCountry, 50);
			validator.StringLength("ValSizem2", Resources.Resources.SIZE10299, ValSizem2, 50);
			validator.StringLength("BrokerValEmail", Resources.Resources.EMAIL25170, BrokerValEmail, 256);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL TRA VIEWMODEL_SAVE F_PROPERTY]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL TRA VIEWMODEL_APPLY F_PROPERTY]/

// USE /[MANUAL TRA VIEWMODEL_DUPLICATE F_PROPERTY]/

// USE /[MANUAL TRA VIEWMODEL_DESTROY F_PROPERTY]/
		public override void Destroy(string id)
		{
			Model = Models.Properties.Find(id, m_userContext, "FF_PROPERTY");
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
		/// TableCityCity -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_F_property__city__city(NameValueCollection qs, bool lazyLoad = false)
		{
			bool f_property__city__cityDoLoad = true;
			CriteriaSet f_property__city__cityConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("city", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					f_property__city__cityConds.Equal(CSGenioAcity.FldCodcity, hValue);
					this.ValCodcity_fk = DBConversion.ToString(hValue);
				}
			}

			TableCityCity = new TableDBEdit<Models.City>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_city") != null)
				{
					this.ValCodcity_fk = Navigation.GetStrValue("RETURN_city");
					Navigation.CurrentLevel.SetEntry("RETURN_city", null);
				}
				FillDependant_F_propertyTableCityCity(lazyLoad);
				return;
			}

			if (f_property__city__cityDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableCityCity, "sTableCityCity", "dTableCityCity", qs, "city");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableCityCity_tableFilters"]))
					TableCityCity.TableFilters = bool.Parse(qs["TableCityCity_tableFilters"]);
				else
					TableCityCity.TableFilters = false;

				query = qs["qTableCityCity"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAcity.FldCity, query + "%");
				}
				f_property__city__cityConds.SubSet(search_filters);

				string tryParsePage = qs["pTableCityCity"] != null ? qs["pTableCityCity"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAcity.FldCodcity, CSGenioAcity.FldCity, CSGenioAcity.FldZzstate];

// USE /[MANUAL TRA OVERRQ F_PROPERTY_CITYCITY]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("city", FormMode.New) || Navigation.checkFormMode("city", FormMode.Duplicate))
					f_property__city__cityConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcity.FldZzstate, 0)
						.Equal(CSGenioAcity.FldCodcity, Navigation.GetStrValue("city")));
				else
					f_property__city__cityConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcity.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("city", "city");
				ListingMVC<CSGenioAcity> listing = Models.ModelBase.Where<CSGenioAcity>(m_userContext, false, f_property__city__cityConds, fields, offset, numberItems, sorts, "LED_F_PROPERTY__CITY__CITY", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCityCity.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCityCity.Query = query;
				TableCityCity.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.City(m_userContext, r, true, _fieldsToSerialize_F_PROPERTY__CITY__CITY));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_city") != null)
				{
					this.ValCodcity_fk = Navigation.GetStrValue("RETURN_city");
					Navigation.CurrentLevel.SetEntry("RETURN_city", null);
				}

				TableCityCity.List = new SelectList(TableCityCity.Elements.ToSelectList(x => x.ValCity, x => x.ValCodcity,  x => x.ValCodcity == this.ValCodcity_fk), "Value", "Text", this.ValCodcity_fk);
				FillDependant_F_propertyTableCityCity();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCityCity (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of City</param>
		public ConcurrentDictionary<string, object> GetDependant_F_propertyTableCityCity(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAcity.FldCodcity, CSGenioAcity.FldCity, CSGenioAcountry.FldCodcountry, CSGenioAcountry.FldCountry];

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

			CSGenioAcity tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAcity.FldCodcity, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableCityCity (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_F_propertyTableCityCity(bool lazyLoad = false)
		{
			var row = GetDependant_F_propertyTableCityCity(this.ValCodcity_fk);
			try
			{
				this.funcCityCountryValCountry = () => (string)row["country.country"];

				// Fill List fields
				this.ValCodcity_fk = ViewModelConversion.ToString(row["city.codcity"]);
				TableCityCity.Value = (string)row["city.city"];
				if (GenFunctions.emptyG(this.ValCodcity_fk) == 1)
				{
					this.ValCodcity_fk = "";
					TableCityCity.Value = "";
					Navigation.ClearValue("city");
				}
				else if (lazyLoad)
				{
					TableCityCity.SetPagination(1, 0, false, false, 1);
					TableCityCity.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodcity_fk),
							Text = Convert.ToString(TableCityCity.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodcity_fk);
				}

				TableCityCity.Selected = this.ValCodcity_fk;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCityCity): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_F_PROPERTY__CITY__CITY = ["City", "City.ValCodcity", "City.ValZzstate", "City.ValCity"];

		/// <summary>
		/// TableBrokerName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_F_property__broker__name(NameValueCollection qs, bool lazyLoad = false)
		{
			bool f_property__broker__nameDoLoad = true;
			CriteriaSet f_property__broker__nameConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("broker", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					f_property__broker__nameConds.Equal(CSGenioAbroker.FldCodbroker, hValue);
					this.ValBroker_fk = DBConversion.ToString(hValue);
				}
			}

			TableBrokerName = new TableDBEdit<Models.Broker>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_broker") != null)
				{
					this.ValBroker_fk = Navigation.GetStrValue("RETURN_broker");
					Navigation.CurrentLevel.SetEntry("RETURN_broker", null);
				}
				FillDependant_F_propertyTableBrokerName(lazyLoad);
				return;
			}

			if (f_property__broker__nameDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableBrokerName, "sTableBrokerName", "dTableBrokerName", qs, "broker");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableBrokerName_tableFilters"]))
					TableBrokerName.TableFilters = bool.Parse(qs["TableBrokerName_tableFilters"]);
				else
					TableBrokerName.TableFilters = false;

				query = qs["qTableBrokerName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAbroker.FldName, query + "%");
				}
				f_property__broker__nameConds.SubSet(search_filters);

				string tryParsePage = qs["pTableBrokerName"] != null ? qs["pTableBrokerName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAbroker.FldCodbroker, CSGenioAbroker.FldName, CSGenioAbroker.FldZzstate];

// USE /[MANUAL TRA OVERRQ F_PROPERTY_BROKERNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("broker", FormMode.New) || Navigation.checkFormMode("broker", FormMode.Duplicate))
					f_property__broker__nameConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAbroker.FldZzstate, 0)
						.Equal(CSGenioAbroker.FldCodbroker, Navigation.GetStrValue("broker")));
				else
					f_property__broker__nameConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAbroker.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("broker", "name");
				ListingMVC<CSGenioAbroker> listing = Models.ModelBase.Where<CSGenioAbroker>(m_userContext, false, f_property__broker__nameConds, fields, offset, numberItems, sorts, "LED_F_PROPERTY__BROKER__NAME", true, false, firstVisibleColumn: firstVisibleColumn);

				TableBrokerName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableBrokerName.Query = query;
				TableBrokerName.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Broker(m_userContext, r, true, _fieldsToSerialize_F_PROPERTY__BROKER__NAME));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_broker") != null)
				{
					this.ValBroker_fk = Navigation.GetStrValue("RETURN_broker");
					Navigation.CurrentLevel.SetEntry("RETURN_broker", null);
				}

				TableBrokerName.List = new SelectList(TableBrokerName.Elements.ToSelectList(x => x.ValName, x => x.ValCodbroker,  x => x.ValCodbroker == this.ValBroker_fk), "Value", "Text", this.ValBroker_fk);
				FillDependant_F_propertyTableBrokerName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableBrokerName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Broker</param>
		public ConcurrentDictionary<string, object> GetDependant_F_propertyTableBrokerName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAbroker.FldCodbroker, CSGenioAbroker.FldName, CSGenioAbroker.FldMain_photo, CSGenioAbroker.FldEmail];

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

			CSGenioAbroker tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAbroker.FldCodbroker, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableBrokerName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_F_propertyTableBrokerName(bool lazyLoad = false)
		{
			var row = GetDependant_F_propertyTableBrokerName(this.ValBroker_fk);
			try
			{
				this.funcBrokerValMain_photo = () => (GenioMVC.Models.ImageModel)row["broker.main_photo"];
				this.funcBrokerValEmail = () => (string)row["broker.email"];

				// Fill List fields
				this.ValBroker_fk = ViewModelConversion.ToString(row["broker.codbroker"]);
				TableBrokerName.Value = (string)row["broker.name"];
				if (GenFunctions.emptyG(this.ValBroker_fk) == 1)
				{
					this.ValBroker_fk = "";
					TableBrokerName.Value = "";
					Navigation.ClearValue("broker");
				}
				else if (lazyLoad)
				{
					TableBrokerName.SetPagination(1, 0, false, false, 1);
					TableBrokerName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValBroker_fk),
							Text = Convert.ToString(TableBrokerName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValBroker_fk);
				}

				TableBrokerName.Selected = this.ValBroker_fk;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableBrokerName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_F_PROPERTY__BROKER__NAME = ["Broker", "Broker.ValCodbroker", "Broker.ValZzstate", "Broker.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"properties.broker_fk" => ViewModelConversion.ToString(modelValue),
				"properties.codcity_fk" => ViewModelConversion.ToString(modelValue),
				"properties.main_photo" => ViewModelConversion.ToImage(modelValue),
				"properties.sold" => ViewModelConversion.ToLogic(modelValue),
				"properties.title" => ViewModelConversion.ToString(modelValue),
				"properties.price" => ViewModelConversion.ToNumeric(modelValue),
				"properties.description" => ViewModelConversion.ToString(modelValue),
				"country.country" => ViewModelConversion.ToString(modelValue),
				"properties.bathroomsnumber" => ViewModelConversion.ToNumeric(modelValue),
				"properties.sizem2" => ViewModelConversion.ToString(modelValue),
				"properties.buildingtype" => ViewModelConversion.ToString(modelValue),
				"properties.dateconstruction" => ViewModelConversion.ToDateTime(modelValue),
				"properties.order" => ViewModelConversion.ToNumeric(modelValue),
				"properties.typology" => ViewModelConversion.ToNumeric(modelValue),
				"broker.main_photo" => ViewModelConversion.ToImage(modelValue),
				"broker.email" => ViewModelConversion.ToString(modelValue),
				"properties.codproperties" => ViewModelConversion.ToString(modelValue),
				"city.codcity" => ViewModelConversion.ToString(modelValue),
				"city.city" => ViewModelConversion.ToString(modelValue),
				"country.codcountry" => ViewModelConversion.ToString(modelValue),
				"broker.codbroker" => ViewModelConversion.ToString(modelValue),
				"broker.name" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		/// <inheritdoc/>
		protected override void SetTicketToImageFields()
		{
			if (ValMain_photo != null)
				ValMain_photo.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaPROPERTIES, CSGenioAproperties.FldMain_photo.Field, null, ValCodproperties);
			if (BrokerValMain_photo != null)
				BrokerValMain_photo.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaBROKER, CSGenioAbroker.FldMain_photo.Field, null, ValBroker_fk);
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL TRA VIEWMODEL_CUSTOM F_PROPERTY]/

		#endregion
	}
}
