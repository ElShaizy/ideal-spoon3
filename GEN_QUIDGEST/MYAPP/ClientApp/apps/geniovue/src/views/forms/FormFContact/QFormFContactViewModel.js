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
			name: 'F_CONTACT',
			area: 'CONTACT',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_F_contact',
				updateFilesTickets: 'UpdateFilesTicketsF_contact',
				setFile: 'SetFileF_contact'
			}
		})

		/** The primary key. */
		this.ValCodcontact = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodcontact',
			originId: 'ValCodcontact',
			area: 'CONTACT',
			field: 'CODCONTACT',
			description: computed(() => this.Resources.CONTACT59247),
		}).cloneFrom(values?.ValCodcontact))
		this.stopWatchers.push(watch(() => this.ValCodcontact.value, (newValue, oldValue) => this.onUpdate('contact.codcontact', this.ValCodcontact, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodproperties_fk = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodproperties_fk',
			originId: 'ValCodproperties_fk',
			area: 'CONTACT',
			field: 'CODPROPERTIES_FK',
			relatedArea: 'PROPERTIES',
			description: computed(() => this.Resources.PROPERTIES32002),
		}).cloneFrom(values?.ValCodproperties_fk))
		this.stopWatchers.push(watch(() => this.ValCodproperties_fk.value, (newValue, oldValue) => this.onUpdate('contact.codproperties_fk', this.ValCodproperties_fk, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValClient_name = reactive(new modelFieldType.String({
			id: 'ValClient_name',
			originId: 'ValClient_name',
			area: 'CONTACT',
			field: 'CLIENT_NAME',
			maxLength: 50,
			description: computed(() => this.Resources.CLIENT_NAME39245),
		}).cloneFrom(values?.ValClient_name))
		this.stopWatchers.push(watch(() => this.ValClient_name.value, (newValue, oldValue) => this.onUpdate('contact.client_name', this.ValClient_name, newValue, oldValue)))

		this.ValPhonecontact = reactive(new modelFieldType.Number({
			id: 'ValPhonecontact',
			originId: 'ValPhonecontact',
			area: 'CONTACT',
			field: 'PHONECONTACT',
			maxDigits: 15,
			decimalDigits: 0,
			description: computed(() => this.Resources.PHONE_NUMBER05968),
		}).cloneFrom(values?.ValPhonecontact))
		this.stopWatchers.push(watch(() => this.ValPhonecontact.value, (newValue, oldValue) => this.onUpdate('contact.phonecontact', this.ValPhonecontact, newValue, oldValue)))

		this.ValEmailcontact = reactive(new modelFieldType.String({
			id: 'ValEmailcontact',
			originId: 'ValEmailcontact',
			area: 'CONTACT',
			field: 'EMAILCONTACT',
			maxLength: 256,
			description: computed(() => this.Resources.EMAIL55616),
		}).cloneFrom(values?.ValEmailcontact))
		this.stopWatchers.push(watch(() => this.ValEmailcontact.value, (newValue, oldValue) => this.onUpdate('contact.emailcontact', this.ValEmailcontact, newValue, oldValue)))

		this.ValDate = reactive(new modelFieldType.Date({
			id: 'ValDate',
			originId: 'ValDate',
			area: 'CONTACT',
			field: 'DATE',
			description: computed(() => this.Resources.DATE18475),
		}).cloneFrom(values?.ValDate))
		this.stopWatchers.push(watch(() => this.ValDate.value, (newValue, oldValue) => this.onUpdate('contact.date', this.ValDate, newValue, oldValue)))

		this.TablePropertiesTitle = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePropertiesTitle',
			originId: 'ValTitle',
			area: 'PROPERTIES',
			field: 'TITLE',
			maxLength: 50,
			description: computed(() => this.Resources.TITLE21885),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TablePropertiesTitle))
		this.stopWatchers.push(watch(() => this.TablePropertiesTitle.value, (newValue, oldValue) => this.onUpdate('properties.title', this.TablePropertiesTitle, newValue, oldValue)))

		this.ValDescription = reactive(new modelFieldType.MultiLineString({
			id: 'ValDescription',
			originId: 'ValDescription',
			area: 'CONTACT',
			field: 'DESCRIPTION',
			showWhen: {
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: isEmptyC([CONTACT->PHONECONTACT])
					return (this.ValPhonecontact.value === '')
				},
				dependencyEvents: ['fieldChange:contact.phonecontact'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			description: computed(() => this.Resources.DESCRIPTION03846),
		}).cloneFrom(values?.ValDescription))
		this.stopWatchers.push(watch(() => this.ValDescription.value, (newValue, oldValue) => this.onUpdate('contact.description', this.ValDescription, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormFContactViewModel instance.
	 * @returns {QFormFContactViewModel} A new instance of QFormFContactViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodcontact'

	get QPrimaryKey() { return this.ValCodcontact.value }
	set QPrimaryKey(value) { this.ValCodcontact.updateValue(value) }
}
