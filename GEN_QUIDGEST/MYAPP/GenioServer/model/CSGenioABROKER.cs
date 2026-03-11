
 
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
	/// Broker
	/// </summary>
	public class CSGenioAbroker : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAbroker(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL TRA CONSTRUTOR BROKER]/
		}

		public CSGenioAbroker(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codbroker", FieldType.KEY_INT);
			Qfield.FieldDescription = "broker";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "BROKER37082";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "main_photo", FieldType.IMAGE);
			Qfield.FieldDescription = "Photo";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PHOTO51874";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "name", FieldType.TEXT);
			Qfield.FieldDescription = "Name";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "NAME31974";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "birthdate", FieldType.DATE);
			Qfield.FieldDescription = "Birthdate";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "BIRTHDATE22743";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "email", FieldType.TEXT);
			Qfield.FieldDescription = "Email";
			Qfield.FieldSize =  256;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "EMAIL25170";

			Qfield.Dupmsg = "";
			Qfield.DefaultValue = new DefaultValue("@agent.com");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "phone_number", FieldType.TEXT);
			Qfield.FieldDescription = "Phone Number";
			Qfield.FieldSize =  12;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PHONE_NUMBER31368";

			Qfield.Dupmsg = "";
			Qfield.FillingRule = (rule) =>
			{
				string mask = "00000 000000";
				string validation = "00000 000000";
				return Validation.validateMP(rule, mask, validation);
			};
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "noofproperties", FieldType.NUMERIC);
			Qfield.FieldDescription = "number of properties";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 8;
			Qfield.CavDesignation = "NUMBER_OF_PROPERTIES52479";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "salesprofit", FieldType.CURRENCY);
			Qfield.FieldDescription = "sales profit";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 7;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "SALES_PROFIT14192";

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
			info.ChildTable = new ChildRelation[1];
			info.ChildTable[0]= new ChildRelation("properties", new String[] {"broker_fk"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(0);
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.DefaultValues = new string[] {
			 "email"
			};


			info.RelatedSumFields = new string[] {
			 "noofproperties","salesprofit"
			};





			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAbroker()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="TRA";
			info.TableName="trabroker";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codbroker";
			info.HumanKeyName="name,".TrimEnd(',');
			info.Alias="broker";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Broker";
			info.AreaPluralDesignation="Brokers";
			info.DescriptionCav="BROKER49181";

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

		/// <summary>Field : "broker" Tipo: "+" Formula:  ""</summary>
		public static FieldRef FldCodbroker { get { return m_fldCodbroker; } }
		private static FieldRef m_fldCodbroker = new FieldRef("broker", "codbroker");

		/// <summary>Field : "broker" Tipo: "+" Formula:  ""</summary>
		public string ValCodbroker
		{
			get { return (string)returnValueField(FldCodbroker); }
			set { insertNameValueField(FldCodbroker, value); }
		}

		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldMain_photo { get { return m_fldMain_photo; } }
		private static FieldRef m_fldMain_photo = new FieldRef("broker", "main_photo");

		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValMain_photo
		{
			get { return (byte[])returnValueField(FldMain_photo); }
			set { insertNameValueField(FldMain_photo, value); }
		}

		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldName { get { return m_fldName; } }
		private static FieldRef m_fldName = new FieldRef("broker", "name");

		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public string ValName
		{
			get { return (string)returnValueField(FldName); }
			set { insertNameValueField(FldName, value); }
		}

		/// <summary>Field : "Birthdate" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldBirthdate { get { return m_fldBirthdate; } }
		private static FieldRef m_fldBirthdate = new FieldRef("broker", "birthdate");

		/// <summary>Field : "Birthdate" Tipo: "D" Formula:  ""</summary>
		public DateTime ValBirthdate
		{
			get { return (DateTime)returnValueField(FldBirthdate); }
			set { insertNameValueField(FldBirthdate, value); }
		}

		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldEmail { get { return m_fldEmail; } }
		private static FieldRef m_fldEmail = new FieldRef("broker", "email");

		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public string ValEmail
		{
			get { return (string)returnValueField(FldEmail); }
			set { insertNameValueField(FldEmail, value); }
		}

		/// <summary>Field : "Phone Number" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldPhone_number { get { return m_fldPhone_number; } }
		private static FieldRef m_fldPhone_number = new FieldRef("broker", "phone_number");

		/// <summary>Field : "Phone Number" Tipo: "C" Formula:  ""</summary>
		public string ValPhone_number
		{
			get { return (string)returnValueField(FldPhone_number); }
			set { insertNameValueField(FldPhone_number, value); }
		}

		/// <summary>Field : "number of properties" Tipo: "N" Formula: SR "[PROPERTIES->1]"</summary>
		public static FieldRef FldNoofproperties { get { return m_fldNoofproperties; } }
		private static FieldRef m_fldNoofproperties = new FieldRef("broker", "noofproperties");

		/// <summary>Field : "number of properties" Tipo: "N" Formula: SR "[PROPERTIES->1]"</summary>
		public decimal ValNoofproperties
		{
			get { return (decimal)returnValueField(FldNoofproperties); }
			set { insertNameValueField(FldNoofproperties, value); }
		}

		/// <summary>Field : "sales profit" Tipo: "$" Formula: SR "[PROPERTIES->PRICE]"</summary>
		public static FieldRef FldSalesprofit { get { return m_fldSalesprofit; } }
		private static FieldRef m_fldSalesprofit = new FieldRef("broker", "salesprofit");

		/// <summary>Field : "sales profit" Tipo: "$" Formula: SR "[PROPERTIES->PRICE]"</summary>
		public decimal ValSalesprofit
		{
			get { return (decimal)returnValueField(FldSalesprofit); }
			set { insertNameValueField(FldSalesprofit, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("broker", "zzstate");



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
        public static CSGenioAbroker search(PersistentSupport sp, string key, User user, string[] fields = null, bool forUpdate = false)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAbroker area = new CSGenioAbroker(user, user.CurrentModule);

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
        public static List<CSGenioAbroker> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAbroker>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAbroker> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAbroker>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL TRA TABAUX BROKER]/

 
         

	}
}
