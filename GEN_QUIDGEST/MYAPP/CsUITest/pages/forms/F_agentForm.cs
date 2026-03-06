using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class F_agentForm : Form
{
	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl AgentPhoto => new BaseInputControl(driver, ContainerLocator, "container-F_AGENT_AGENTPHOTO___", "#F_AGENT_AGENTPHOTO___");

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl AgentName => new BaseInputControl(driver, ContainerLocator, "container-F_AGENT_AGENTNAME____", "#F_AGENT_AGENTNAME____");

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl AgentEmail => new BaseInputControl(driver, ContainerLocator, "container-F_AGENT_AGENTEMAIL___", "#F_AGENT_AGENTEMAIL___");

	/// <summary>
	/// Birthdate
	/// </summary>
	public DateInputControl AgentBirthdate => new DateInputControl(driver, ContainerLocator, "#F_AGENT__AGENT__BIRTHDATE");

	public F_agentForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "F_AGENT", containerLocator: containerLocator) { }
}
