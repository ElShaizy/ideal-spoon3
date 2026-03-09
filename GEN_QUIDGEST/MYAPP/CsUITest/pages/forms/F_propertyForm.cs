using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class F_propertyForm : Form
{
	/// <summary>
	/// Main Photo
	/// </summary>
	public BaseInputControl PropertiesMain_photo => new BaseInputControl(driver, ContainerLocator, "container-F_PROPERTY__PROPERTIES__MAIN_PHOTO", "#F_PROPERTY__PROPERTIES__MAIN_PHOTO");

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl PropertiesTitle => new BaseInputControl(driver, ContainerLocator, "container-F_PROPERTY__PROPERTIES__TITLE", "#F_PROPERTY__PROPERTIES__TITLE");

	/// <summary>
	/// Price
	/// </summary>
	public BaseInputControl PropertiesPrice => new BaseInputControl(driver, ContainerLocator, "container-F_PROPERTY__PROPERTIES__PRICE", "#F_PROPERTY__PROPERTIES__PRICE");

	/// <summary>
	/// Broker Name
	/// </summary>
	public BaseInputControl PropertiesBroker_name => new BaseInputControl(driver, ContainerLocator, "container-F_PROPERTY__PROPERTIES__BROKER_NAME", "#F_PROPERTY__PROPERTIES__BROKER_NAME");

	public F_propertyForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "F_PROPERTY", containerLocator: containerLocator) { }
}
