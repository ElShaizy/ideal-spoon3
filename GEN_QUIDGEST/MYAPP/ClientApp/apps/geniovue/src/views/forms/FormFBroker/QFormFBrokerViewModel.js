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
			name: 'F_BROKER',
			area: 'BROKER',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_F_broker',
				updateFilesTickets: 'UpdateFilesTicketsF_broker',
				setFile: 'SetFileF_broker'
			}
		})

		/** The primary key. */
		this.ValCodbroker = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodbroker',
			originId: 'ValCodbroker',
			area: 'BROKER',
			field: 'CODBROKER',
			description: '',
		}).cloneFrom(values?.ValCodbroker))
		this.stopWatchers.push(watch(() => this.ValCodbroker.value, (newValue, oldValue) => this.onUpdate('broker.codbroker', this.ValCodbroker, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValMain_photo = reactive(new modelFieldType.Image({
			id: 'ValMain_photo',
			originId: 'ValMain_photo',
			area: 'BROKER',
			field: 'PHOTO',
			description: computed(() => this.Resources.PHOTO51874),
		}).cloneFrom(values?.ValMain_photo))
		this.stopWatchers.push(watch(() => this.ValMain_photo.value, (newValue, oldValue) => this.onUpdate('broker.main_photo', this.ValMain_photo, newValue, oldValue)))

		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'BROKER',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		this.stopWatchers.push(watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('broker.name', this.ValName, newValue, oldValue)))

		this.ValBirthdate = reactive(new modelFieldType.Date({
			id: 'ValBirthdate',
			originId: 'ValBirthdate',
			area: 'BROKER',
			field: 'BIRTHDATE',
			description: computed(() => this.Resources.BIRTHDATE22743),
		}).cloneFrom(values?.ValBirthdate))
		this.stopWatchers.push(watch(() => this.ValBirthdate.value, (newValue, oldValue) => this.onUpdate('broker.birthdate', this.ValBirthdate, newValue, oldValue)))

		this.ValEmail = reactive(new modelFieldType.String({
			id: 'ValEmail',
			originId: 'ValEmail',
			area: 'BROKER',
			field: 'EMAIL',
			maxLength: 256,
			description: computed(() => this.Resources.EMAIL25170),
		}).cloneFrom(values?.ValEmail))
		this.stopWatchers.push(watch(() => this.ValEmail.value, (newValue, oldValue) => this.onUpdate('broker.email', this.ValEmail, newValue, oldValue)))

		this.ValPhone_number = reactive(new modelFieldType.String({
			id: 'ValPhone_number',
			originId: 'ValPhone_number',
			area: 'BROKER',
			field: 'PHONE_NUMBER',
			maxLength: 12,
			maskType: 'MP',
			maskFormat: '00000 000000',
			maskRequired: '00000 000000',
			description: computed(() => this.Resources.PHONE_NUMBER31368),
		}).cloneFrom(values?.ValPhone_number))
		this.stopWatchers.push(watch(() => this.ValPhone_number.value, (newValue, oldValue) => this.onUpdate('broker.phone_number', this.ValPhone_number, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormFBrokerViewModel instance.
	 * @returns {QFormFBrokerViewModel} A new instance of QFormFBrokerViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodbroker'

	get QPrimaryKey() { return this.ValCodbroker.value }
	set QPrimaryKey(value) { this.ValCodbroker.updateValue(value) }
}
