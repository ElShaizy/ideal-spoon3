using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class F_brokerForm : Form
{
	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl BrokerPhoto => new BaseInputControl(driver, ContainerLocator, "container-F_BROKER__BROKER__PHOTO", "#F_BROKER__BROKER__PHOTO");

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl BrokerName => new BaseInputControl(driver, ContainerLocator, "container-F_BROKER__BROKER__NAME", "#F_BROKER__BROKER__NAME");

	/// <summary>
	/// Birthdate
	/// </summary>
	public DateInputControl BrokerBirthdate => new DateInputControl(driver, ContainerLocator, "#F_BROKER__BROKER__BIRTHDATE");

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl BrokerEmail => new BaseInputControl(driver, ContainerLocator, "container-F_BROKER__BROKER__EMAIL", "#F_BROKER__BROKER__EMAIL");

	public F_brokerForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "F_BROKER", containerLocator: containerLocator) { }
}
