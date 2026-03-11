
 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using CSGenio.framework;
using CSGenio.persistence;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;
using System.Linq;

namespace CSGenio.business
{
	/// <summary>
	/// Property
	/// </summary>
	public class CSGenioAproperties : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAproperties(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL TRA CONSTRUTOR PROPERTIES]/
		}

		public CSGenioAproperties(User user) : this(user, user.CurrentModule)
		{
		}

		/// <summary>
		/// Initializes the metadata relative to the fields of this area
		/// </summary>
		private static void InicializaCampos(AreaInfo info)
		{
			Field Qfield = null;
#pragma warning disable CS0168, S1481 // Variable is declared but never used
			List<ByAreaArguments> argumentsListByArea;
#pragma warning restore CS0168, S1481 // Variable is declared but never used
			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codproperties", FieldType.KEY_INT);
			Qfield.FieldDescription = "properties";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PROPERTIES32002";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "broker_fk", FieldType.KEY_INT);
			Qfield.FieldDescription = "brokers";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "BROKERS62836";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codcity_fk", FieldType.KEY_INT);
			Qfield.FieldDescription = "city";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CITY35974";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "main_photo", FieldType.IMAGE);
			Qfield.FieldDescription = "Main Photo";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "MAIN_PHOTO18723";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "title", FieldType.TEXT);
			Qfield.FieldDescription = "Title";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "TITLE21885";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "price", FieldType.CURRENCY);
			Qfield.FieldDescription = "Price";
			Qfield.FieldSize =  15;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 10;
			Qfield.Decimals = 4;
			Qfield.CavDesignation = "PRICE06900";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "sizem2", FieldType.TEXT);
			Qfield.FieldDescription = "size m2";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "SIZE_M254142";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "bathroomsnumber", FieldType.NUMERIC);
			Qfield.FieldDescription = "Bathroom count";
			Qfield.FieldSize =  15;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 15;
			Qfield.CavDesignation = "BATHROOM_COUNT05757";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "dateconstruction", FieldType.DATE);
			Qfield.FieldDescription = "Construction date";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CONSTRUCTION_DATE18132";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "description", FieldType.MEMO);
			Qfield.FieldDescription = "Description";
			Qfield.FieldSize =  500;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DESCRIPTION07383";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "buildingtype", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "building type";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "BUILDING_TYPE34158";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCbuilding_type";
            Qfield.ArrayClassName = "Building_type";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "typology", FieldType.ARRAY_NUMERIC);
			Qfield.FieldDescription = "Typology";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "TYPOLOGY11991";

			Qfield.Dupmsg = "";
			Qfield.ArrayName = "dbo.GetValArrayNtypology";
            Qfield.ArrayClassName = "Typology";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "order", FieldType.NUMERIC);
			Qfield.FieldDescription = "ID";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 8;
			Qfield.CavDesignation = "ID48520";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "buildingage", FieldType.NUMERIC);
			Qfield.FieldDescription = "building age";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "BUILDING_AGE37966";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"dateconstruction"}, new int[] {0}, "properties", "codproperties"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return GenFunctions.Year(DateTime.Today)-GenFunctions.Year(((DateTime)args[0]));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "groundsize", FieldType.NUMERIC);
			Qfield.FieldDescription = "groundsize";
			Qfield.FieldSize =  6;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 6;
			Qfield.CavDesignation = "GROUNDSIZE44655";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"buildingtype"}, new int[] {0}, "properties", "codproperties"));
			Qfield.ShowWhen = new ConditionFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((string)args[0])=="H";
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "floornumber", FieldType.NUMERIC);
			Qfield.FieldDescription = "floor number";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 3;
			Qfield.CavDesignation = "FLOOR_NUMBER35331";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "sold", FieldType.LOGIC);
			Qfield.FieldDescription = "sold";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "SOLD56700";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "solddate", FieldType.DATE);
			Qfield.FieldDescription = "Date sold";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DATE_SOLD35096";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"sold"}, new int[] {0}, "properties", "codproperties"));
			Qfield.ShowWhen = new ConditionFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((int)args[0])==1;
			});
			Qfield.DefaultValue = new DefaultValue(DefaultValue.getToday);
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "zzstate", FieldType.INTEGER);
			Qfield.FieldDescription = "Estado da ficha";
			info.RegisterFieldDB(Qfield);

		}

		/// <summary>
		/// Initializes metadata for paths direct to other areas
		/// </summary>
		private static void InicializaRelacoes(AreaInfo info)
		{
			// Daughters Relations
			//------------------------------
			info.ChildTable = new ChildRelation[2];
			info.ChildTable[0]= new ChildRelation("contact", new String[] {"codproperties_fk"}, DeleteProc.NA);
			info.ChildTable[1]= new ChildRelation("photo_album", new String[] {"codproperties_fk"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("broker", new Relation("TRA", "traproperties", "properties", "codproperties", "broker_fk", "TRA", "trabroker", "broker", "codbroker", "codbroker"));
			info.ParentTables.Add("city", new Relation("TRA", "traproperties", "properties", "codproperties", "codcity_fk", "TRA", "tracity", "city", "codcity", "codcity"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(3);
			info.Pathways.Add("broker","broker");
			info.Pathways.Add("city","city");
			info.Pathways.Add("country","city");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------
			//Actualiza as seguintes somas relacionadas:
			info.RelatedSumArgs = new List<RelatedSumArgument>();
			info.RelatedSumArgs.Add( new RelatedSumArgument("properties", "broker", "salesprofit", "price", '+', true));
			info.RelatedSumArgs.Add( new RelatedSumArgument("properties", "broker", "noofproperties", "1", '+', false));



			//Actualiza as seguintes rotinas de ultimo Qvalue:
			info.LastValueArgs = new List<LastValueArgument>();
			info.LastValueArgs.Add( new LastValueArgument("broker",
				new string [] {"lastsold"},
				new string [] {"price"},
				"solddate",
				null,

				null, false));


			info.InternalOperationFields = new string[] {
			 "buildingage"
			};

			info.DefaultValues = new string[] {
			 "solddate"
			};






			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();

			// [PROPERTIES->PRICE]>0
			{
			List<ByAreaArguments> argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea= new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"price"},new int[] {0},"properties","codproperties"));
			ConditionFormula writeCondition = new ConditionFormula(argumentsListByArea, 1, delegate(object []args,User user,string module,PersistentSupport sp) {
				return ((decimal)args[0])>0;
			});
			writeCondition.ErrorWarning = "you cannot save a property with no price";
            writeCondition.Type =  ConditionType.ERROR;
            writeCondition.Validate = true;
			conditions.Add(writeCondition);
			}
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAproperties()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="TRA";
			info.TableName="traproperties";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codproperties";
			info.HumanKeyName="title,price,".TrimEnd(',');
			info.Alias="properties";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Property";
			info.AreaPluralDesignation="Properties";
			info.DescriptionCav="PROPERTY43977";

			//sincronização
			info.SyncIncrementalDateStart = TimeSpan.FromHours(8);
			info.SyncIncrementalDateEnd = TimeSpan.FromHours(23);
			info.SyncCompleteHour = TimeSpan.FromHours(0.5);
			info.SyncIncrementalPeriod = TimeSpan.FromHours(1);
			info.BatchSync = 100;
			info.SyncType = SyncType.Central;
            info.SolrList = new List<string>();
        	info.QueuesList = new List<GenioServer.business.QueueGenio>();





			//RS 22.03.2011 I separated in submetodos due to performance problems with the JIT in 64bits
			// that in very large projects took 2 minutes on the first call.
			// After a Microsoft analysis of the JIT algortimo it was revealed that it has a
			// complexity O(n*m) where n are the lines of code and m the number of variables of a function.
			// Tests have revealed that splitting into subfunctions cuts the JIT time by more than half by 64-bit.
			//------------------------------
			InicializaCampos(info);

			//------------------------------
			InicializaRelacoes(info);

			//------------------------------
			InicializaCaminhos(info);

			//------------------------------
			InicializaFormulas(info);

			// Automatic audit stamps in BD
            //------------------------------

            // Documents in DB
            //------------------------------

            // Historics
            //------------------------------

			// Duplication
			//------------------------------

			// Ephs
			//------------------------------
			info.Ephs=new Hashtable();

			// Table minimum roles and access levels
			//------------------------------
            info.QLevel = new QLevel();
            info.QLevel.Query = Role.AUTHORIZED;
            info.QLevel.Create = Role.AUTHORIZED;
            info.QLevel.AlterAlways = Role.AUTHORIZED;
            info.QLevel.RemoveAlways = Role.AUTHORIZED;

      		return info;
		}

		/// <summary>
		/// Meta-information about this area
		/// </summary>
		public override AreaInfo Information
		{
			get { return informacao; }
		}
		/// <summary>
		/// Meta-information about this area
		/// </summary>
		public static AreaInfo GetInformation()
		{
			return informacao;
		}

		/// <summary>Field : "properties" Tipo: "+" Formula:  ""</summary>
		public static FieldRef FldCodproperties { get { return m_fldCodproperties; } }
		private static FieldRef m_fldCodproperties = new FieldRef("properties", "codproperties");

		/// <summary>Field : "properties" Tipo: "+" Formula:  ""</summary>
		public string ValCodproperties
		{
			get { return (string)returnValueField(FldCodproperties); }
			set { insertNameValueField(FldCodproperties, value); }
		}

		/// <summary>Field : "brokers" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldBroker_fk { get { return m_fldBroker_fk; } }
		private static FieldRef m_fldBroker_fk = new FieldRef("properties", "broker_fk");

		/// <summary>Field : "brokers" Tipo: "CE" Formula:  ""</summary>
		public string ValBroker_fk
		{
			get { return (string)returnValueField(FldBroker_fk); }
			set { insertNameValueField(FldBroker_fk, value); }
		}

		/// <summary>Field : "city" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodcity_fk { get { return m_fldCodcity_fk; } }
		private static FieldRef m_fldCodcity_fk = new FieldRef("properties", "codcity_fk");

		/// <summary>Field : "city" Tipo: "CE" Formula:  ""</summary>
		public string ValCodcity_fk
		{
			get { return (string)returnValueField(FldCodcity_fk); }
			set { insertNameValueField(FldCodcity_fk, value); }
		}

		/// <summary>Field : "Main Photo" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldMain_photo { get { return m_fldMain_photo; } }
		private static FieldRef m_fldMain_photo = new FieldRef("properties", "main_photo");

		/// <summary>Field : "Main Photo" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValMain_photo
		{
			get { return (byte[])returnValueField(FldMain_photo); }
			set { insertNameValueField(FldMain_photo, value); }
		}

		/// <summary>Field : "Title" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldTitle { get { return m_fldTitle; } }
		private static FieldRef m_fldTitle = new FieldRef("properties", "title");

		/// <summary>Field : "Title" Tipo: "C" Formula:  ""</summary>
		public string ValTitle
		{
			get { return (string)returnValueField(FldTitle); }
			set { insertNameValueField(FldTitle, value); }
		}

		/// <summary>Field : "Price" Tipo: "$" Formula:  ""</summary>
		public static FieldRef FldPrice { get { return m_fldPrice; } }
		private static FieldRef m_fldPrice = new FieldRef("properties", "price");

		/// <summary>Field : "Price" Tipo: "$" Formula:  ""</summary>
		public decimal ValPrice
		{
			get { return (decimal)returnValueField(FldPrice); }
			set { insertNameValueField(FldPrice, value); }
		}

		/// <summary>Field : "size m2" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldSizem2 { get { return m_fldSizem2; } }
		private static FieldRef m_fldSizem2 = new FieldRef("properties", "sizem2");

		/// <summary>Field : "size m2" Tipo: "C" Formula:  ""</summary>
		public string ValSizem2
		{
			get { return (string)returnValueField(FldSizem2); }
			set { insertNameValueField(FldSizem2, value); }
		}

		/// <summary>Field : "Bathroom count" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldBathroomsnumber { get { return m_fldBathroomsnumber; } }
		private static FieldRef m_fldBathroomsnumber = new FieldRef("properties", "bathroomsnumber");

		/// <summary>Field : "Bathroom count" Tipo: "N" Formula:  ""</summary>
		public decimal ValBathroomsnumber
		{
			get { return (decimal)returnValueField(FldBathroomsnumber); }
			set { insertNameValueField(FldBathroomsnumber, value); }
		}

		/// <summary>Field : "Construction date" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldDateconstruction { get { return m_fldDateconstruction; } }
		private static FieldRef m_fldDateconstruction = new FieldRef("properties", "dateconstruction");

		/// <summary>Field : "Construction date" Tipo: "D" Formula:  ""</summary>
		public DateTime ValDateconstruction
		{
			get { return (DateTime)returnValueField(FldDateconstruction); }
			set { insertNameValueField(FldDateconstruction, value); }
		}

		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldDescription { get { return m_fldDescription; } }
		private static FieldRef m_fldDescription = new FieldRef("properties", "description");

		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		public string ValDescription
		{
			get { return (string)returnValueField(FldDescription); }
			set { insertNameValueField(FldDescription, value); }
		}

		/// <summary>Field : "building type" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldBuildingtype { get { return m_fldBuildingtype; } }
		private static FieldRef m_fldBuildingtype = new FieldRef("properties", "buildingtype");

		/// <summary>Field : "building type" Tipo: "AC" Formula:  ""</summary>
		public string ValBuildingtype
		{
			get { return (string)returnValueField(FldBuildingtype); }
			set { insertNameValueField(FldBuildingtype, value); }
		}

		/// <summary>Field : "Typology" Tipo: "AN" Formula:  ""</summary>
		public static FieldRef FldTypology { get { return m_fldTypology; } }
		private static FieldRef m_fldTypology = new FieldRef("properties", "typology");

		/// <summary>Field : "Typology" Tipo: "AN" Formula:  ""</summary>
		public decimal ValTypology
		{
			get { return (decimal)returnValueField(FldTypology); }
			set { insertNameValueField(FldTypology, value); }
		}

		/// <summary>Field : "ID" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldOrder { get { return m_fldOrder; } }
		private static FieldRef m_fldOrder = new FieldRef("properties", "order");

		/// <summary>Field : "ID" Tipo: "N" Formula:  ""</summary>
		public decimal ValOrder
		{
			get { return (decimal)returnValueField(FldOrder); }
			set { insertNameValueField(FldOrder, value); }
		}

		/// <summary>Field : "building age" Tipo: "N" Formula: + "Year([Today]) - Year([PROPERTIES->DATECONSTRUCTION])"</summary>
		public static FieldRef FldBuildingage { get { return m_fldBuildingage; } }
		private static FieldRef m_fldBuildingage = new FieldRef("properties", "buildingage");

		/// <summary>Field : "building age" Tipo: "N" Formula: + "Year([Today]) - Year([PROPERTIES->DATECONSTRUCTION])"</summary>
		public decimal ValBuildingage
		{
			get { return (decimal)returnValueField(FldBuildingage); }
			set { insertNameValueField(FldBuildingage, value); }
		}

		/// <summary>Field : "groundsize" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldGroundsize { get { return m_fldGroundsize; } }
		private static FieldRef m_fldGroundsize = new FieldRef("properties", "groundsize");

		/// <summary>Field : "groundsize" Tipo: "N" Formula:  ""</summary>
		public decimal ValGroundsize
		{
			get { return (decimal)returnValueField(FldGroundsize); }
			set { insertNameValueField(FldGroundsize, value); }
		}

		/// <summary>Field : "floor number" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldFloornumber { get { return m_fldFloornumber; } }
		private static FieldRef m_fldFloornumber = new FieldRef("properties", "floornumber");

		/// <summary>Field : "floor number" Tipo: "N" Formula:  ""</summary>
		public decimal ValFloornumber
		{
			get { return (decimal)returnValueField(FldFloornumber); }
			set { insertNameValueField(FldFloornumber, value); }
		}

		/// <summary>Field : "sold" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldSold { get { return m_fldSold; } }
		private static FieldRef m_fldSold = new FieldRef("properties", "sold");

		/// <summary>Field : "sold" Tipo: "L" Formula:  ""</summary>
		public int ValSold
		{
			get { return (int)returnValueField(FldSold); }
			set { insertNameValueField(FldSold, value); }
		}

		/// <summary>Field : "Date sold" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldSolddate { get { return m_fldSolddate; } }
		private static FieldRef m_fldSolddate = new FieldRef("properties", "solddate");

		/// <summary>Field : "Date sold" Tipo: "D" Formula:  ""</summary>
		public DateTime ValSolddate
		{
			get { return (DateTime)returnValueField(FldSolddate); }
			set { insertNameValueField(FldSolddate, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("properties", "zzstate");



		/// <summary>Field : "ZZSTATE" Type: "INT"</summary>
		public int ValZzstate
		{
			get { return (int)returnValueField(FldZzstate); }
			set { insertNameValueField(FldZzstate, value); }
		}

        /// <summary>
        /// Obtains a partially populated area with the record corresponding to a primary key
        /// </summary>
        /// <param name="sp">Persistent support from where to get the registration</param>
        /// <param name="key">The value of the primary key</param>
        /// <param name="user">The context of the user</param>
        /// <param name="fields">The fields to be filled in the area</param>
		/// <param name="forUpdate">True if you are preparing to update this record, false otherwise</param>
        /// <returns>An area with the fields requests of the record read or null if the key does not exist</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static CSGenioAproperties search(PersistentSupport sp, string key, User user, string[] fields = null, bool forUpdate = false)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAproperties area = new CSGenioAproperties(user, user.CurrentModule);

            if (sp.getRecord(area, key, fields, forUpdate))
                return area;
			return null;
        }


		public static string GetkeyFromControlledRecord(PersistentSupport sp, string ID, User user)
		{
			if (informacao.ControlledRecords != null)
				return informacao.ControlledRecords.GetPrimaryKeyFromControlledRecord(sp, user, ID);
			return String.Empty;
		}


        /// <summary>
        /// Search for all records of this area that comply with a condition
        /// </summary>
        /// <param name="sp">Persistent support from where to get the list</param>
        /// <param name="user">The context of the user</param>
        /// <param name="where">The search condition for the records. Use null to get all records</param>
        /// <param name="fields">The fields to be filled in the area</param>
        /// <param name="distinct">Get distinct from fields</param>
        /// <param name="noLock">NOLOCK</param>
        /// <returns>A list of area records with all fields populated</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static List<CSGenioAproperties> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAproperties>(where, user, fields, distinct, noLock);
        }



       	/// <summary>
        /// Search for all records of this area that comply with a condition
        /// </summary>
        /// <param name="sp">Persistent support from where to get the list</param>
        /// <param name="user">The context of the user</param>
        /// <param name="where">The search condition for the records. Use null to get all records</param>
        /// <param name="listing">List configuration</param>
        /// <returns>A list of area records with all fields populated</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAproperties> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAproperties>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL TRA TABAUX PROPERTIES]/

 
                   

	}
}
