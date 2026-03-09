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
			description: '',
		}).cloneFrom(values?.ValCodproperties))
		this.stopWatchers.push(watch(() => this.ValCodproperties.value, (newValue, oldValue) => this.onUpdate('properties.codproperties', this.ValCodproperties, newValue, oldValue)))

		/** The hidden foreign keys. */
		this.ValBroker_fk = reactive(new modelFieldType.ForeignKey({
			id: 'ValBroker_fk',
			originId: 'ValBroker_fk',
			area: 'PROPERTIES',
			field: 'BROKER_FK',
			relatedArea: 'BROKER',
			isFixed: true,
			description: '',
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

		this.ValBroker_name = reactive(new modelFieldType.String({
			id: 'ValBroker_name',
			originId: 'ValBroker_name',
			area: 'PROPERTIES',
			field: 'BROKER_NAME',
			maxLength: 50,
			description: computed(() => this.Resources.BROKER_NAME33548),
		}).cloneFrom(values?.ValBroker_name))
		this.stopWatchers.push(watch(() => this.ValBroker_name.value, (newValue, oldValue) => this.onUpdate('properties.broker_name', this.ValBroker_name, newValue, oldValue)))
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
