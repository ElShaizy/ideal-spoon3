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

	public F_cityForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "F_CITY", containerLocator: containerLocator) { }
}
