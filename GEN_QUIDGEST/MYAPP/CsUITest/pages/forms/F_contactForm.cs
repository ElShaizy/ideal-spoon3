using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class F_contactForm : Form
{
	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl ContactDate => new DateInputControl(driver, ContainerLocator, "#F_CONTACT__CONTACT__DATE");

	/// <summary>
	/// Title
	/// </summary>
	public LookupControl PropertiesTitle => new LookupControl(driver, ContainerLocator, "container-F_CONTACT__PROPERTIES__TITLE");
	public SeeMorePage PropertiesTitleSeeMorePage => new SeeMorePage(driver, "F_CONTACT", "F_CONTACT__PROPERTIES__TITLE");

	/// <summary>
	/// Client name
	/// </summary>
	public BaseInputControl ContactClient_name => new BaseInputControl(driver, ContainerLocator, "container-F_CONTACT__CONTACT__CLIENT_NAME", "#F_CONTACT__CONTACT__CLIENT_NAME");

	/// <summary>
	/// email
	/// </summary>
	public BaseInputControl ContactEmailcontact => new BaseInputControl(driver, ContainerLocator, "container-F_CONTACT__CONTACT__EMAILCONTACT", "#F_CONTACT__CONTACT__EMAILCONTACT");

	/// <summary>
	/// phone number
	/// </summary>
	public BaseInputControl ContactPhonecontact => new BaseInputControl(driver, ContainerLocator, "container-F_CONTACT__CONTACT__PHONECONTACT", "#F_CONTACT__CONTACT__PHONECONTACT");

	/// <summary>
	/// description
	/// </summary>
	public BaseInputControl ContactDescription => new BaseInputControl(driver, ContainerLocator, "container-F_CONTACT__CONTACT__DESCRIPTION", "#F_CONTACT__CONTACT__DESCRIPTION");

	public F_contactForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "F_CONTACT", containerLocator: containerLocator) { }
}
