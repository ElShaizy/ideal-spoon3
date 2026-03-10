using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class F_countryForm : Form
{
	/// <summary>
	/// Country
	/// </summary>
	public BaseInputControl CountryCountry => new BaseInputControl(driver, ContainerLocator, "container-F_COUNTRY__COUNTRY__COUNTRY", "#F_COUNTRY__COUNTRY__COUNTRY");

	public F_countryForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "F_COUNTRY", containerLocator: containerLocator) { }
}
