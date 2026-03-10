using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array building_type (building type)
	/// </summary>
	public class ArrayBuilding_type : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayBuilding_type _instance = new ArrayBuilding_type();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayBuilding_type Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Apartment
		/// </summary>
		public const string E_A_1 = "A";
		/// <summary>
		/// House
		/// </summary>
		public const string E_H_2 = "H";
		/// <summary>
		/// Other
		/// </summary>
		public const string E_O_3 = "O";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayBuilding_type"/> class from being created.
		/// </summary>
		private ArrayBuilding_type() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_A_1, new ArrayElement() { ResourceId = "APARTMENT12665", HelpId = "", Group = "" } },
				{ E_H_2, new ArrayElement() { ResourceId = "HOUSE01993", HelpId = "", Group = "" } },
				{ E_O_3, new ArrayElement() { ResourceId = "OTHER37293", HelpId = "", Group = "" } },
			};
		}

		/// <summary>
		/// Gets the element's description.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string CodToDescricao(string cod)
		{
			return Instance.CodToDescricaoImpl(cod);
		}

		/// <summary>
		/// Gets the elements.
		/// </summary>
		/// <returns></returns>
		public static List<string> GetElements()
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
            return Instance.GetElementImpl(cod);
        }

		/// <summary>
		/// Gets the dictionary.
		/// </summary>
		/// <returns></returns>
		public static IDictionary<string, string> GetDictionary()
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
			return Instance.GetHelpIdImpl(cod);
		}
	}
}
