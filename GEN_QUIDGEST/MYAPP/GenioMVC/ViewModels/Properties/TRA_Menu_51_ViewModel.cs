using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.core.di;
using CSGenio.core.framework.table;
using CSGenio.framework;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Properties
{
	public class TRA_Menu_51_ViewModel : MenuListViewModel<Models.Properties>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("table")]
		public TablePartial<TRA_Menu_51_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "properties";

		/// <inheritdoc/>
		[JsonPropertyName("uuid")]
		public override string Uuid => "0208c5d1-59f0-44a7-afd6-ceab834ec31c";

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize => _fieldsToSerialize;

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns => _searchableColumns;

		/// <summary>
		/// The context of the parent.
		/// </summary>
		[JsonIgnore]
		public Models.ModelBase ParentCtx { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override CriteriaSet StaticLimits
		{
			get
			{
				CriteriaSet conditions = CriteriaSet.And();

				return conditions;
			}
		}

		/// <inheritdoc/>
		[JsonIgnore]
		public override CriteriaSet BaseConditions
		{
			get
			{
				CriteriaSet conds = CriteriaSet.And();

				return conds;
			}
		}

		/// <inheritdoc/>
		[JsonIgnore]
		public override List<Relation> Relations
		{
			get
			{
				List<Relation> relations = null;
				return relations;
			}
		}

		public override CriteriaSet GetCustomizedStaticLimits(CriteriaSet crs)
		{
// USE /[MANUAL TRA LIST_LIMITS 51]/

			return crs;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("properties", user, "TRA");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML51");
			conditions.Equal(CSGenioAproperties.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAproperties.FldCodproperties, CSGenioAproperties.FldZzstate, CSGenioAproperties.FldDescription, CSGenioAproperties.FldBuildingage, CSGenioAproperties.FldTitle, CSGenioAproperties.FldTypology, CSGenioAproperties.FldPrice, CSGenioAproperties.FldDateconstruction, CSGenioAproperties.FldBroker_fk, CSGenioAbroker.FldCodbroker, CSGenioAbroker.FldName, CSGenioAproperties.FldBuildingtype, CSGenioAproperties.FldOrder, CSGenioAproperties.FldBathroomsnumber, CSGenioAproperties.FldSizem2, CSGenioAproperties.FldMain_photo };

			ListingMVC<CSGenioAproperties> listing = new(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

			// Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);



			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// </summary>
		[Obsolete("For deserialization only")]
		public TRA_Menu_51_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="TRA_Menu_51_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public TRA_Menu_51_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TRA_Menu_51_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public TRA_Menu_51_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAproperties.FldDescription, FieldType.MEMO, Resources.Resources.DESCRIPTION07383, 30, 0, true),
				new Exports.QColumn(CSGenioAproperties.FldBuildingage, FieldType.NUMERIC, Resources.Resources.BUILDING_AGE37966, 10, 0, true),
				new Exports.QColumn(CSGenioAproperties.FldTitle, FieldType.TEXT, Resources.Resources.TITLE21885, 30, 0, true),
				new Exports.QColumn(CSGenioAproperties.FldTypology, FieldType.ARRAY_NUMERIC, Resources.Resources.TYPOLOGY11991, 1, 0, true, "typology"),
				new Exports.QColumn(CSGenioAproperties.FldPrice, FieldType.CURRENCY, Resources.Resources.PRICE06900, 15, 2, true),
				new Exports.QColumn(CSGenioAproperties.FldDateconstruction, FieldType.DATE, Resources.Resources.CONSTRUCTION_DATE18132, 8, 0, true),
				new Exports.QColumn(CSGenioAbroker.FldName, FieldType.TEXT, Resources.Resources.NAME31974, 30, 0, true),
				new Exports.QColumn(CSGenioAproperties.FldBuildingtype, FieldType.ARRAY_TEXT, Resources.Resources.BUILDING_TYPE34158, 1, 0, true, "building_type"),
				new Exports.QColumn(CSGenioAproperties.FldOrder, FieldType.NUMERIC, Resources.Resources.ID48520, 8, 0, true),
				new Exports.QColumn(CSGenioAproperties.FldBathroomsnumber, FieldType.NUMERIC, Resources.Resources.BATHROOM_COUNT05757, 15, 0, true),
				new Exports.QColumn(CSGenioAproperties.FldSizem2, FieldType.TEXT, Resources.Resources.SIZE_M254142, 30, 2, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAproperties> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAproperties> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			listing = null;
			conditions = null;
			columns = this.GetExportColumns(tableConfig.ColumnConfigurations);

			// Store number of records to reset it after loading
			int rowsPerPage = tableConfig.RowsPerPage;
			tableConfig.RowsPerPage = -1;

			Load(tableConfig, requestValues, ajaxRequest, true, ref listing, ref conditions);

			// Reset number of records to original value
			tableConfig.RowsPerPage = rowsPerPage;
		}

		/// <inheritdoc/>
		public override CriteriaSet BuildCriteriaSet(NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			return BuildCriteriaSet(tableConfig, requestValues, out tableReload, crs, isToExport);
		}

		/// <inheritdoc/>
		public override CriteriaSet BuildCriteriaSet(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			User u = m_userContext.User;
			tableReload = true;

			crs ??= CriteriaSet.And();

			Menu ??= new TablePartial<TRA_Menu_51_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, true);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfigurations), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			if (!tableConfig.GroupFilters.ContainsKey("filter_TRA_Menu_51_BUILDINGTY"))
			{
				string defaultValue = "";
				tableConfig.Filters.Add(new GroupFilter { Key = "filter_TRA_Menu_51_BUILDINGTY", Value = defaultValue });
			}

			{
				var groupFilters = CriteriaSet.Or();
				bool filter_TRA_Menu_51_BUILDINGTY_1 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_TRA_Menu_51_BUILDINGTY"))
					filter_TRA_Menu_51_BUILDINGTY_1 = tableConfig.GroupFilters["filter_TRA_Menu_51_BUILDINGTY"].Contains("1");
				if (filter_TRA_Menu_51_BUILDINGTY_1)
				{
					groupFilters.Equal(CSGenioAproperties.FldBuildingtype, "A");

				}

				bool filter_TRA_Menu_51_BUILDINGTY_2 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_TRA_Menu_51_BUILDINGTY"))
					filter_TRA_Menu_51_BUILDINGTY_2 = tableConfig.GroupFilters["filter_TRA_Menu_51_BUILDINGTY"].Contains("2");
				if (filter_TRA_Menu_51_BUILDINGTY_2)
				{
					groupFilters.Equal(CSGenioAproperties.FldBuildingtype, "H");

				}

				bool filter_TRA_Menu_51_BUILDINGTY_3 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_TRA_Menu_51_BUILDINGTY"))
					filter_TRA_Menu_51_BUILDINGTY_3 = tableConfig.GroupFilters["filter_TRA_Menu_51_BUILDINGTY"].Contains("3");
				if (filter_TRA_Menu_51_BUILDINGTY_3)
				{
					groupFilters.Equal(CSGenioAproperties.FldBuildingtype, "O");

				}

				bool filter_TRA_Menu_51_BUILDINGTY_4 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_TRA_Menu_51_BUILDINGTY"))
					filter_TRA_Menu_51_BUILDINGTY_4 = tableConfig.GroupFilters["filter_TRA_Menu_51_BUILDINGTY"].Contains("4");
				if (filter_TRA_Menu_51_BUILDINGTY_4)
				{

				}

				subfilters.SubSets.Add(groupFilters);
			}

			crs.SubSets.Add(subfilters);

			// Form field filters
			crs.SubSets.Add(ProcessFieldFilters(tableConfig.GlobalFilters));

			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			if (isToExport)
			{
				// EPH
				crs = Models.Properties.AddEPH<CSGenioAproperties>(ref u, crs, "ML51");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAproperties.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("PROPERTIES", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAproperties.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_properties");
				Navigation.DestroyEntry("QMVC_POS_RECORD_properties");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Properties.AddEPH<CSGenioAproperties>(ref u, null, "ML51"));
			}

			return crs;
		}

		/// <summary>
		/// Loads the list with the specified number of rows.
		/// </summary>
		/// <param name="numberListItems">The number of rows to load.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		public void Load(int numberListItems, bool ajaxRequest = false)
		{
			Load(numberListItems, new NameValueCollection(), ajaxRequest);
		}

		/// <summary>
		/// Loads the list with the specified number of rows.
		/// </summary>
		/// <param name="numberListItems">The number of rows to load.</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest = false, CriteriaSet conditions = null)
		{
			ListingMVC<CSGenioAproperties> listing = null;

			Load(numberListItems, requestValues, ajaxRequest, false, ref listing, ref conditions);
		}

		/// <summary>
		/// Loads the list with the specified number of rows.
		/// </summary>
		/// <param name="numberListItems">The number of rows to load.</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="isToExport">Whether the list is being loaded to be exported</param>
		/// <param name="Qlisting">The rows.</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAproperties> Qlisting, ref CriteriaSet conditions)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();

			tableConfig.RowsPerPage = numberListItems;

			Load(tableConfig, requestValues, ajaxRequest, isToExport, ref Qlisting, ref conditions);
		}

		/// <summary>
		/// Loads the table with the specified configuration.
		/// </summary>
		/// <param name="tableConfig">The table configuration object</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="isToExport">Whether the list is being loaded to be exported</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport = false, CriteriaSet conditions = null)
		{
			ListingMVC<CSGenioAproperties> listing = null;

			Load(tableConfig, requestValues, ajaxRequest, isToExport, ref listing, ref conditions);
		}

		/// <summary>
		/// Loads the table with the specified configuration.
		/// </summary>
		/// <param name="tableConfig">The table configuration object</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="isToExport">Whether the list is being loaded to be exported</param>
		/// <param name="Qlisting">The rows.</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAproperties> Qlisting, ref CriteriaSet conditions)
		{
			User u = m_userContext.User;
			Menu = new TablePartial<TRA_Menu_51_RowViewModel>();

			CriteriaSet tra_menu_51Conds = CriteriaSet.And();
			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("PROPERTIES.TITLE", new OrderedDictionary());
			allSortOrders["PROPERTIES.TITLE"].Add("PROPERTIES.TITLE", "A");


			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig, "properties", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAproperties.FldTitle), SortOrder.Ascending));

			}

			FieldRef[] fields = new FieldRef[] { CSGenioAproperties.FldCodproperties, CSGenioAproperties.FldZzstate, CSGenioAproperties.FldDescription, CSGenioAproperties.FldBuildingage, CSGenioAproperties.FldTitle, CSGenioAproperties.FldTypology, CSGenioAproperties.FldPrice, CSGenioAproperties.FldDateconstruction, CSGenioAproperties.FldBroker_fk, CSGenioAbroker.FldCodbroker, CSGenioAbroker.FldName, CSGenioAproperties.FldBuildingtype, CSGenioAproperties.FldOrder, CSGenioAproperties.FldBathroomsnumber, CSGenioAproperties.FldSizem2, CSGenioAproperties.FldMain_photo };


			// Totalizers
			List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

			FieldRef firstVisibleColumn = null;

			if (sorts.Count == 0)
			{
				firstVisibleColumn = tableConfig?.GetFirstVisibleColumn(TableAlias);

				firstVisibleColumn ??= new FieldRef("properties", "description");
			}
			// Limitations
			this.TableLimits ??= [];
			// Comparer to check if limit is already present in TableLimits
			LimitComparer limitComparer = new();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAproperties model_limit_area = new CSGenioAproperties(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML51");
				if (area_EPH_limits.Count > 0)
					this.TableLimits.AddRange(area_EPH_limits);
			}


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(tra_menu_51Conds);
			tra_menu_51Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL TRA OVERRQ 51]/

			bool distinct = false;

			if (isToExport)
			{
				if (!tableReload)
					return;

				var exportColumns = GetExportColumns(tableConfig.ColumnConfigurations);
				var exportFieldRefs = exportColumns.Select(eCol => eCol.Field).Where(fldRef => fldRef != null).ToArray();

				Qlisting = Models.ModelBase.BuildListingForExport<CSGenioAproperties>(m_userContext, false, ref tra_menu_51Conds, exportFieldRefs, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML51", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL TRA OVERRQLSTEXP 51]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL TRA OVERRQLIST 51]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_properties");
				Navigation.DestroyEntry("QMVC_POS_RECORD_properties");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAproperties.GetInformation(), QMVC_POS_RECORD, sorts, tra_menu_51Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioAproperties> listing = Models.ModelBase.Where<CSGenioAproperties>(m_userContext, distinct, tra_menu_51Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML51", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapTRA_Menu_51(listing);

				Menu.Identifier = "ML51";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML51";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);

				// Set table totalizers
				if (listing.Totalizers != null && listing.Totalizers.Count > 0)
					Menu.SetTotalizers(listing.Totalizers);
			}

			// Set table limits display property
			FillTableLimitsDisplayData();

			// Store table configuration so it gets sent to the client-side to be processed
			CurrentTableConfig = tableConfig;

			// Load the user table configuration names and default name
			LoadUserTableConfigNameProperties();
		}

		private List<TRA_Menu_51_RowViewModel> MapTRA_Menu_51(ListingMVC<CSGenioAproperties> Qlisting)
		{
			List<TRA_Menu_51_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapTRA_Menu_51(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAproperties row
		/// to a TRA_Menu_51_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private TRA_Menu_51_RowViewModel MapTRA_Menu_51(CSGenioAproperties row)
		{
			var model = new TRA_Menu_51_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "properties":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "broker":
						model.Broker.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					default:
						break;
				}
			}

			model.InitRowData();

			SetTicketToImageFields(model);
			return model;
		}

		/// <summary>
		/// Checks the loaded model for pending rows (zzsttate not 0).
		/// </summary>
		public bool CheckForZzstate()
		{
			if (Menu?.Elements == null)
				return false;

			return Menu.Elements.Any(row => row.ValZzstate != 0);
		}

		/// <summary>
		/// Sets the document field values to objects.
		/// </summary>
		/// <param name="listing">The rows</param>
		private void SetDocumentFields(ListingMVC<CSGenioAproperties> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Properties m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Properties m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL TRA VIEWMODEL_CUSTOM TRA_MENU_51]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Properties", "Properties.ValCodproperties", "Properties.ValZzstate", "Properties.ValDescription", "Properties.ValBuildingage", "Properties.ValTitle", "Properties.ValTypology", "Properties.ValPrice", "Properties.ValDateconstruction", "Broker", "Broker.ValName", "Properties.ValBuildingtype", "Properties.ValOrder", "Properties.ValBathroomsnumber", "Properties.ValSizem2", "Properties.ValMain_photo", "Properties.ValBroker_fk", "Properties.ValCodcity_fk"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValDescription", CSGenioAproperties.FldDescription, typeof(string)),
			new TableSearchColumn("ValBuildingage", CSGenioAproperties.FldBuildingage, typeof(decimal?)),
			new TableSearchColumn("ValTitle", CSGenioAproperties.FldTitle, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValTypology", CSGenioAproperties.FldTypology, typeof(decimal), array : "typology"),
			new TableSearchColumn("ValPrice", CSGenioAproperties.FldPrice, typeof(decimal?)),
			new TableSearchColumn("ValDateconstruction", CSGenioAproperties.FldDateconstruction, typeof(DateTime?)),
			new TableSearchColumn("Broker_ValName", CSGenioAbroker.FldName, typeof(string)),
			new TableSearchColumn("ValBuildingtype", CSGenioAproperties.FldBuildingtype, typeof(string), array : "building_type"),
			new TableSearchColumn("ValOrder", CSGenioAproperties.FldOrder, typeof(decimal?)),
			new TableSearchColumn("ValBathroomsnumber", CSGenioAproperties.FldBathroomsnumber, typeof(decimal?)),
			new TableSearchColumn("ValSizem2", CSGenioAproperties.FldSizem2, typeof(string)),
		];
		protected void SetTicketToImageFields(Models.Properties row)
		{
			if (row == null)
				return;

			row.ValMain_photoQTicket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaPROPERTIES, CSGenioAproperties.FldMain_photo.Field, null, row.ValCodproperties);
		}
	}
}
