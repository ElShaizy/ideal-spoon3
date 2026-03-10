using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array typology (typology)
	/// </summary>
	public class ArrayTypology : Array<decimal>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayTypology _instance = new ArrayTypology();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayTypology Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.NUMERIC; } }

		/// <summary>
		/// no bedrooms
		/// </summary>
		public const decimal E_0_1 = 0M;
		/// <summary>
		/// one bedroom house
		/// </summary>
		public const decimal E_1_2 = 1M;
		/// <summary>
		/// two bedroom house
		/// </summary>
		public const decimal E_2_3 = 2M;
		/// <summary>
		/// three bedroom house
		/// </summary>
		public const decimal E_3_4 = 3M;
		/// <summary>
		/// 3+ bedrooms house
		/// </summary>
		public const decimal E_4_5 = 4M;

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayTypology"/> class from being created.
		/// </summary>
		private ArrayTypology() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<decimal, ArrayElement> LoadDictionary()
		{
			return new Dictionary<decimal, ArrayElement>()
			{
				{ E_0_1, new ArrayElement() { ResourceId = "NO_BEDROOMS37059", HelpId = "", Group = "" } },
				{ E_1_2, new ArrayElement() { ResourceId = "ONE_BEDROOM_HOUSE63269", HelpId = "", Group = "" } },
				{ E_2_3, new ArrayElement() { ResourceId = "TWO_BEDROOM_HOUSE28362", HelpId = "", Group = "" } },
				{ E_3_4, new ArrayElement() { ResourceId = "THREE_BEDROOM_HOUSE32899", HelpId = "", Group = "" } },
				{ E_4_5, new ArrayElement() { ResourceId = "_3__BEDROOMS_HOUSE62907", HelpId = "", Group = "" } },
			};
		}

		/// <summary>
		/// Gets the element's description.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string CodToDescricao(decimal cod)
		{
			return Instance.CodToDescricaoImpl(cod);
		}

		/// <summary>
		/// Gets the elements.
		/// </summary>
		/// <returns></returns>
		public static List<decimal> GetElements()
		{
			return Instance.GetElementsImpl();
		}

		/// <summary>
		/// Gets the element.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static ArrayElement GetElement(string cod)
		{
            return Instance.GetElementImpl(decimal.Parse(cod));
        }

		/// <summary>
		/// Gets the dictionary.
		/// </summary>
		/// <returns></returns>
		public static IDictionary<decimal, string> GetDictionary()
		{
			return Instance.GetDictionaryImpl();
		}

		/// <summary>
		/// Gets the help identifier.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string GetHelpId(string cod)
		{
			return Instance.GetHelpIdImpl(decimal.Parse(cod));
		}
	}
}
