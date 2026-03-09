
 
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
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "main photo", FieldType.IMAGE);
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
			Qfield = new Field(info.Alias, "broker_fk", FieldType.KEY_INT);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
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

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("broker", new Relation("TRA", "traproperties", "properties", "codproperties", "broker_fk", "TRA", "trabroker", "broker", "codbroker", "codbroker"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(1);
			info.Pathways.Add("broker","broker");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------








			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
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

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public static FieldRef FldCodproperties { get { return m_fldCodproperties; } }
		private static FieldRef m_fldCodproperties = new FieldRef("properties", "codproperties");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodproperties
		{
			get { return (string)returnValueField(FldCodproperties); }
			set { insertNameValueField(FldCodproperties, value); }
		}

		/// <summary>Field : "Main Photo" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldMain photo { get { return m_fldMain photo; } }
		private static FieldRef m_fldMain photo = new FieldRef("properties", "main photo");

		/// <summary>Field : "Main Photo" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValMain photo
		{
			get { return (byte[])returnValueField(FldMain photo); }
			set { insertNameValueField(FldMain photo, value); }
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

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldBroker_fk { get { return m_fldBroker_fk; } }
		private static FieldRef m_fldBroker_fk = new FieldRef("properties", "broker_fk");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValBroker_fk
		{
			get { return (string)returnValueField(FldBroker_fk); }
			set { insertNameValueField(FldBroker_fk, value); }
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
