using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class F_cityForm : Form
{
	/// <summary>
	/// City
	/// </summary>
	public BaseInputControl CityCity => new BaseInputControl(driver, ContainerLocator, "container-F_CITY__CITY_CITY____", "#F_CITY__CITY_CITY____");

	/// <summary>
	/// Country
	/// </summary>
	public LookupControl CountryCountry => new LookupControl(driver, ContainerLocator, "container-F_CITY__COUNTRY__COUNTRY");
	public SeeMorePage CountryCountrySeeMorePage => new SeeMorePage(driver, "F_CITY", "F_CITY__COUNTRY__COUNTRY");

	public F_cityForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "F_CITY", containerLocator: containerLocator) { }
}
