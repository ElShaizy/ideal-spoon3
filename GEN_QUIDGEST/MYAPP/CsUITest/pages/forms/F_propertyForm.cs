using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class F_propertyForm : Form
{
	/// <summary>
	/// main info
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#F_PROPERTY__PSEUD__NEWGRP01-container");

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
	/// Description
	/// </summary>
	public BaseInputControl PropertiesDescription => new BaseInputControl(driver, ContainerLocator, "container-F_PROPERTY__PROPERTIES__DESCRIPTION", "#F_PROPERTY__PROPERTIES__DESCRIPTION");

	/// <summary>
	/// area
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp02 => new CollapsibleZoneControl(driver, ContainerLocator, "#F_PROPERTY__PSEUD__NEWGRP02-container");

	/// <summary>
	/// City
	/// </summary>
	public LookupControl CityCity => new LookupControl(driver, ContainerLocator, "container-F_PROPERTY__CITY__CITY");
	public SeeMorePage CityCitySeeMorePage => new SeeMorePage(driver, "F_PROPERTY", "F_PROPERTY__CITY__CITY");

	/// <summary>
	/// Country
	/// </summary>
	public IWebElement CountryCountry => throw new NotImplementedException();

	/// <summary>
	/// details
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp03 => new CollapsibleZoneControl(driver, ContainerLocator, "#F_PROPERTY__PSEUD__NEWGRP03-container");

	/// <summary>
	/// Bathroom count
	/// </summary>
	public BaseInputControl PropertiesBathroomsnumber => new BaseInputControl(driver, ContainerLocator, "container-F_PROPERTY__PROPERTIES__BATHROOMSNUMBER", "#F_PROPERTY__PROPERTIES__BATHROOMSNUMBER");

	/// <summary>
	/// Size
	/// </summary>
	public BaseInputControl PropertiesSizem2 => new BaseInputControl(driver, ContainerLocator, "container-F_PROPERTY__PROPERTIES__SIZEM2", "#F_PROPERTY__PROPERTIES__SIZEM2");

	/// <summary>
	/// building type
	/// </summary>
	public EnumControl PropertiesBuildingtype => new EnumControl(driver, ContainerLocator, "container-F_PROPERTY__PROPERTIES__BUILDINGTYPE");

	/// <summary>
	/// Construction date
	/// </summary>
	public DateInputControl PropertiesDateconstruction => new DateInputControl(driver, ContainerLocator, "#F_PROPERTY__PROPERTIES__DATECONSTRUCTION");

	/// <summary>
	/// Typology
	/// </summary>
	public RadiobuttonControl PropertiesTypology => new RadiobuttonControl(driver, ContainerLocator, "container-F_PROPERTY__PROPERTIES__TYPOLOGY");

	/// <summary>
	/// brokers information
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp04 => new CollapsibleZoneControl(driver, ContainerLocator, "#F_PROPERTY__PSEUD__NEWGRP04-container");

	/// <summary>
	/// brokers name
	/// </summary>
	public LookupControl BrokerName => new LookupControl(driver, ContainerLocator, "container-F_PROPERTY__BROKER__NAME");
	public SeeMorePage BrokerNameSeeMorePage => new SeeMorePage(driver, "F_PROPERTY", "F_PROPERTY__BROKER__NAME");

	/// <summary>
	/// Photo
	/// </summary>
	public IWebElement BrokerPhoto => throw new NotImplementedException();

	/// <summary>
	/// Email
	/// </summary>
	public IWebElement BrokerEmail => throw new NotImplementedException();

	/// <summary>
	/// Properties
	/// </summary>
	public ListControl PseudProperty_grid => new ListControl(driver, ContainerLocator, "#F_PROPERTY__PSEUD__PROPERTY_GRID");

	/// <summary>
	/// Contacts
	/// </summary>
	public ListControl PseudContact_grid => new ListControl(driver, ContainerLocator, "#F_PROPERTY__PSEUD__CONTACT_GRID");

	public F_propertyForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "F_PROPERTY", containerLocator: containerLocator) { }
}
