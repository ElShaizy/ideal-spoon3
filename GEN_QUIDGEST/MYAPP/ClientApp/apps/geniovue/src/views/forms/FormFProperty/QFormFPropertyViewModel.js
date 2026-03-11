/* eslint-disable @typescript-eslint/no-unused-vars */
import { computed, reactive, watch } from 'vue'
import _merge from 'lodash-es/merge'

import FormViewModelBase from '@/mixins/formViewModelBase.js'
import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
import modelFieldType from '@quidgest/clientapp/models/fields'

import hardcodedTexts from '@/hardcodedTexts.js'
import netAPI from '@quidgest/clientapp/network'
import qApi from '@/api/genio/quidgestFunctions.js'
import qFunctions from '@/api/genio/projectFunctions.js'
import qProjArrays from '@/api/genio/projectArrays.js'
/* eslint-enable @typescript-eslint/no-unused-vars */

/**
 * Represents a ViewModel class.
 * @extends FormViewModelBase
 */
export default class ViewModel extends FormViewModelBase
{
	/**
	 * Creates a new instance of the ViewModel.
	 * @param {object} vueContext - The Vue context
	 * @param {object} options - The options for the ViewModel
	 * @param {object} values - A ViewModel instance to copy values from
	 */
	// eslint-disable-next-line @typescript-eslint/no-unused-vars
	constructor(vueContext, options, values)
	{
		super(vueContext, options)
		// eslint-disable-next-line @typescript-eslint/no-unused-vars
		const vm = this.vueContext

		// The view model metadata
		_merge(this.modelInfo, {
			name: 'F_PROPERTY',
			area: 'PROPERTIES',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_F_property',
				updateFilesTickets: 'UpdateFilesTicketsF_property',
				setFile: 'SetFileF_property'
			}
		})

		/** The primary key. */
		this.ValCodproperties = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodproperties',
			originId: 'ValCodproperties',
			area: 'PROPERTIES',
			field: 'CODPROPERTIES',
			description: computed(() => this.Resources.PROPERTIES32002),
		}).cloneFrom(values?.ValCodproperties))
		this.stopWatchers.push(watch(() => this.ValCodproperties.value, (newValue, oldValue) => this.onUpdate('properties.codproperties', this.ValCodproperties, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodcity_fk = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcity_fk',
			originId: 'ValCodcity_fk',
			area: 'PROPERTIES',
			field: 'CODCITY_FK',
			relatedArea: 'CITY',
			description: computed(() => this.Resources.CITY35974),
		}).cloneFrom(values?.ValCodcity_fk))
		this.stopWatchers.push(watch(() => this.ValCodcity_fk.value, (newValue, oldValue) => this.onUpdate('properties.codcity_fk', this.ValCodcity_fk, newValue, oldValue)))

		this.ValBroker_fk = reactive(new modelFieldType.ForeignKey({
			id: 'ValBroker_fk',
			originId: 'ValBroker_fk',
			area: 'PROPERTIES',
			field: 'BROKER_FK',
			relatedArea: 'BROKER',
			description: computed(() => this.Resources.BROKERS62836),
		}).cloneFrom(values?.ValBroker_fk))
		this.stopWatchers.push(watch(() => this.ValBroker_fk.value, (newValue, oldValue) => this.onUpdate('properties.broker_fk', this.ValBroker_fk, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValMain_photo = reactive(new modelFieldType.Image({
			id: 'ValMain_photo',
			originId: 'ValMain_photo',
			area: 'PROPERTIES',
			field: 'MAIN_PHOTO',
			description: computed(() => this.Resources.MAIN_PHOTO18723),
		}).cloneFrom(values?.ValMain_photo))
		this.stopWatchers.push(watch(() => this.ValMain_photo.value, (newValue, oldValue) => this.onUpdate('properties.main_photo', this.ValMain_photo, newValue, oldValue)))

		this.ValSold = reactive(new modelFieldType.Boolean({
			id: 'ValSold',
			originId: 'ValSold',
			area: 'PROPERTIES',
			field: 'SOLD',
			description: computed(() => this.Resources.SOLD56700),
		}).cloneFrom(values?.ValSold))
		this.stopWatchers.push(watch(() => this.ValSold.value, (newValue, oldValue) => this.onUpdate('properties.sold', this.ValSold, newValue, oldValue)))

		this.ValTitle = reactive(new modelFieldType.String({
			id: 'ValTitle',
			originId: 'ValTitle',
			area: 'PROPERTIES',
			field: 'TITLE',
			maxLength: 50,
			description: computed(() => this.Resources.TITLE21885),
		}).cloneFrom(values?.ValTitle))
		this.stopWatchers.push(watch(() => this.ValTitle.value, (newValue, oldValue) => this.onUpdate('properties.title', this.ValTitle, newValue, oldValue)))

		this.ValPrice = reactive(new modelFieldType.Number({
			id: 'ValPrice',
			originId: 'ValPrice',
			area: 'PROPERTIES',
			field: 'PRICE',
			maxDigits: 10,
			decimalDigits: 4,
			description: computed(() => this.Resources.PRICE06900),
		}).cloneFrom(values?.ValPrice))
		this.stopWatchers.push(watch(() => this.ValPrice.value, (newValue, oldValue) => this.onUpdate('properties.price', this.ValPrice, newValue, oldValue)))

		this.ValDescription = reactive(new modelFieldType.MultiLineString({
			id: 'ValDescription',
			originId: 'ValDescription',
			area: 'PROPERTIES',
			field: 'DESCRIPTION',
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValDescription))
		this.stopWatchers.push(watch(() => this.ValDescription.value, (newValue, oldValue) => this.onUpdate('properties.description', this.ValDescription, newValue, oldValue)))

		this.TableCityCity = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableCityCity',
			originId: 'ValCity',
			area: 'CITY',
			field: 'CITY',
			maxLength: 50,
			description: computed(() => this.Resources.CITY42505),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableCityCity))
		this.stopWatchers.push(watch(() => this.TableCityCity.value, (newValue, oldValue) => this.onUpdate('city.city', this.TableCityCity, newValue, oldValue)))

		this.CityCountryValCountry = reactive(new modelFieldType.String({
			id: 'CityCountryValCountry',
			originId: 'ValCountry',
			area: 'COUNTRY',
			field: 'COUNTRY',
			maxLength: 50,
			isFixed: true,
			description: computed(() => this.Resources.COUNTRY64133),
		}).cloneFrom(values?.CityCountryValCountry))
		this.stopWatchers.push(watch(() => this.CityCountryValCountry.value, (newValue, oldValue) => this.onUpdate('country.country', this.CityCountryValCountry, newValue, oldValue)))

		this.ValBathroomsnumber = reactive(new modelFieldType.Number({
			id: 'ValBathroomsnumber',
			originId: 'ValBathroomsnumber',
			area: 'PROPERTIES',
			field: 'BATHROOMSNUMBER',
			maxDigits: 15,
			decimalDigits: 0,
			description: computed(() => this.Resources.BATHROOM_COUNT05757),
		}).cloneFrom(values?.ValBathroomsnumber))
		this.stopWatchers.push(watch(() => this.ValBathroomsnumber.value, (newValue, oldValue) => this.onUpdate('properties.bathroomsnumber', this.ValBathroomsnumber, newValue, oldValue)))

		this.ValSizem2 = reactive(new modelFieldType.String({
			id: 'ValSizem2',
			originId: 'ValSizem2',
			area: 'PROPERTIES',
			field: 'SIZEM2',
			maxLength: 50,
			description: computed(() => this.Resources.SIZE_M254142),
		}).cloneFrom(values?.ValSizem2))
		this.stopWatchers.push(watch(() => this.ValSizem2.value, (newValue, oldValue) => this.onUpdate('properties.sizem2', this.ValSizem2, newValue, oldValue)))

		this.ValBuildingtype = reactive(new modelFieldType.String({
			id: 'ValBuildingtype',
			originId: 'ValBuildingtype',
			area: 'PROPERTIES',
			field: 'BUILDINGTYPE',
			maxLength: 1,
			arrayOptions: computed(() => new qProjArrays.QArrayBuilding_type(vm.$getResource).elements),
			description: computed(() => this.Resources.BUILDING_TYPE34158),
		}).cloneFrom(values?.ValBuildingtype))
		this.stopWatchers.push(watch(() => this.ValBuildingtype.value, (newValue, oldValue) => this.onUpdate('properties.buildingtype', this.ValBuildingtype, newValue, oldValue)))

		this.ValDateconstruction = reactive(new modelFieldType.Date({
			id: 'ValDateconstruction',
			originId: 'ValDateconstruction',
			area: 'PROPERTIES',
			field: 'DATECONSTRUCTION',
			description: computed(() => this.Resources.CONSTRUCTION_DATE18132),
		}).cloneFrom(values?.ValDateconstruction))
		this.stopWatchers.push(watch(() => this.ValDateconstruction.value, (newValue, oldValue) => this.onUpdate('properties.dateconstruction', this.ValDateconstruction, newValue, oldValue)))

		this.ValOrder = reactive(new modelFieldType.Number({
			id: 'ValOrder',
			originId: 'ValOrder',
			area: 'PROPERTIES',
			field: 'ORDER',
			maxDigits: 8,
			decimalDigits: 0,
			description: computed(() => this.Resources.ID48520),
		}).cloneFrom(values?.ValOrder))
		this.stopWatchers.push(watch(() => this.ValOrder.value, (newValue, oldValue) => this.onUpdate('properties.order', this.ValOrder, newValue, oldValue)))

		this.ValTypology = reactive(new modelFieldType.Number({
			id: 'ValTypology',
			originId: 'ValTypology',
			area: 'PROPERTIES',
			field: 'TYPOLOGY',
			maxDigits: 1,
			decimalDigits: 0,
			arrayOptions: computed(() => new qProjArrays.QArrayTypology(vm.$getResource).elements),
			description: computed(() => this.Resources.TYPOLOGY11991),
		}).cloneFrom(values?.ValTypology))
		this.stopWatchers.push(watch(() => this.ValTypology.value, (newValue, oldValue) => this.onUpdate('properties.typology', this.ValTypology, newValue, oldValue)))

		this.TableBrokerName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableBrokerName',
			originId: 'ValName',
			area: 'BROKER',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableBrokerName))
		this.stopWatchers.push(watch(() => this.TableBrokerName.value, (newValue, oldValue) => this.onUpdate('broker.name', this.TableBrokerName, newValue, oldValue)))

		this.BrokerValMain_photo = reactive(new modelFieldType.Image({
			id: 'BrokerValMain_photo',
			originId: 'ValMain_photo',
			area: 'BROKER',
			field: 'PHOTO',
			isFixed: true,
			description: computed(() => this.Resources.PHOTO51874),
		}).cloneFrom(values?.BrokerValMain_photo))
		this.stopWatchers.push(watch(() => this.BrokerValMain_photo.value, (newValue, oldValue) => this.onUpdate('broker.main_photo', this.BrokerValMain_photo, newValue, oldValue)))

		this.BrokerValEmail = reactive(new modelFieldType.String({
			id: 'BrokerValEmail',
			originId: 'ValEmail',
			area: 'BROKER',
			field: 'EMAIL',
			maxLength: 256,
			isFixed: true,
			description: computed(() => this.Resources.EMAIL25170),
		}).cloneFrom(values?.BrokerValEmail))
		this.stopWatchers.push(watch(() => this.BrokerValEmail.value, (newValue, oldValue) => this.onUpdate('broker.email', this.BrokerValEmail, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormFPropertyViewModel instance.
	 * @returns {QFormFPropertyViewModel} A new instance of QFormFPropertyViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodproperties'

	get QPrimaryKey() { return this.ValCodproperties.value }
	set QPrimaryKey(value) { this.ValCodproperties.updateValue(value) }
}
